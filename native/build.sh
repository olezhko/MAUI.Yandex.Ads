#!/bin/bash
# Builds YandexAdsBridge.xcframework (device + simulator) from the CocoaPods workspace.
# Output: native/build/YandexAdsBridge.xcframework  (consumed by the .NET binding project)
set -euo pipefail

cd "$(dirname "$0")"
NAME=YandexAdsBridge
OUT=build
CONFIG=${CONFIG:-Release}

# 1. Generate the .xcodeproj (skip if you created/maintain the project by hand in Xcode)
if command -v xcodegen >/dev/null 2>&1; then
  xcodegen generate
elif [ ! -d "$NAME.xcodeproj" ]; then
  echo "error: $NAME.xcodeproj not found and xcodegen not installed (brew install xcodegen)" >&2
  exit 1
fi

# 2. Install pods -> creates $NAME.xcworkspace
pod install --repo-update

rm -rf "$OUT"
mkdir -p "$OUT"

archive() {
  local destination="$1" path="$2"
  xcodebuild archive \
    -workspace "$NAME.xcworkspace" \
    -scheme "$NAME" \
    -configuration "$CONFIG" \
    -destination "$destination" \
    -archivePath "$path" \
    SKIP_INSTALL=NO \
    BUILD_LIBRARY_FOR_DISTRIBUTION=NO \
    -quiet
  test -d "$path.xcarchive/Products/Library/Frameworks/$NAME.framework" \
    || { echo "error: archive for $destination produced no framework" >&2; exit 1; }
}

# 3. Archive device and simulator slices
archive "generic/platform=iOS"           "$OUT/ios"
archive "generic/platform=iOS Simulator" "$OUT/ios-simulator"

# 4. Combine into an xcframework
xcodebuild -create-xcframework -allow-internal-distribution \
  -framework "$OUT/ios.xcarchive/Products/Library/Frameworks/$NAME.framework" \
  -framework "$OUT/ios-simulator.xcarchive/Products/Library/Frameworks/$NAME.framework" \
  -output "$OUT/$NAME.xcframework"

# 5. Sanity checks
FW="$OUT/ios.xcarchive/Products/Library/Frameworks/$NAME.framework"
echo "--- Swift->ObjC header (used for ApiDefinition.cs):"
ls "$FW/Headers"
echo "--- Resource bundles inside the framework (SDK resources from [CP] Copy Pods Resources):"
find "$FW" -maxdepth 1 -name "*.bundle" -print || true
echo "--- Exported Yandex wrapper classes:"
nm -gU "$FW/$NAME" | grep -E "OBJC_CLASS_\\\$_YAB" || true

echo "Done: $OUT/$NAME.xcframework"
