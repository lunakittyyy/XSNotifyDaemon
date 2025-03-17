# XSNotifyDaemon

A C# daemon application that implements the XSOverlay WebSockets notification API and relays them to desktop notifications, without needing XSOverlay.

Intended to be used with Linux and wlxoverlay-s, to provide XSOverlay notifications in VR since XSOverlay is borked on Linux.

As of current, XSNotifyDaemon does not support the legacy UDP protocol in XSOverlay **nor** does it support Windows.  

# Daemon
XSNotifyDaemon past release 0.1.0 (to be released soon) allows for it to be ran as a daemon.

To use the included daemon:
- Move the release files into ''/usr/bin/xsnotifydaemon''
- Optionally symlink ''/usr/bin/XSNotifyDaemon'' to the main executable to make it availiable in your PATH
- Install the systemd service in the repository root
- Enable/start the service