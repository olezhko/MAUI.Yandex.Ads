#!/bin/bash
# Adds any missing Yandex SKAdNetwork IDs to the given Info.plist (macOS only).
# Source list: https://yastatic.net/pcode-static/skadnetwork/skadids.json
# Never fails the build: network/parse problems just print a warning.
PLIST="${1:?usage: update_skad_ids.sh path/to/Info.plist}"
PB=/usr/libexec/PlistBuddy
URL="https://yastatic.net/pcode-static/skadnetwork/skadids.json"

[ -f "$PLIST" ] || { echo "warning: $PLIST not found"; exit 0; }

REMOTE=$(curl -sf --max-time 5 "$URL" | grep -ioE '[a-z0-9]+\.skadnetwork' | tr 'A-Z' 'a-z' | sort -u)
[ -n "$REMOTE" ] || { echo "warning: could not fetch SKAdNetwork IDs, skipping"; exit 0; }

"$PB" -c "Print :SKAdNetworkItems" "$PLIST" >/dev/null 2>&1 || "$PB" -c "Add :SKAdNetworkItems array" "$PLIST"

EXISTING=$("$PB" -c "Print :SKAdNetworkItems" "$PLIST" 2>/dev/null | grep -ioE '[a-z0-9]+\.skadnetwork' | tr 'A-Z' 'a-z' | sort -u)
INDEX=$("$PB" -c "Print :SKAdNetworkItems" "$PLIST" 2>/dev/null | grep -c "Dict")

ADDED=0
for id in $(comm -23 <(echo "$REMOTE") <(echo "$EXISTING")); do
  "$PB" -c "Add :SKAdNetworkItems: dict" \
        -c "Add :SKAdNetworkItems:$INDEX:SKAdNetworkIdentifier string $id" "$PLIST" && {
    INDEX=$((INDEX + 1)); ADDED=$((ADDED + 1)); }
done
echo "SKAdNetwork IDs: +$ADDED new"
