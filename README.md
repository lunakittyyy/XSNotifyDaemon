# XSNotifyDaemon

A C# daemon application that implements the XSOverlay WebSockets notification API and relays them to desktop notifications, without needing XSOverlay.

Intended to be used with Linux and wlxoverlay-s, to provide XSOverlay notifications in VR since XSOverlay is borked on Linux.

As of current, XSNotifyDaemon does not support the legacy UDP protocol in XSOverlay **nor** does it support Windows.  

# systemd Service
XSNotifyDaemon past release 0.1.0 (to be released soon) allows for it to be ran as a systemd service.

To use the included daemon:
- Move the release files into ``/usr/bin/xsnotifydaemon``
- Optionally symlink ``/usr/bin/XSNotifyDaemon`` to the main executable to make it availiable in your PATH
- Install the systemd service located in the repository root into ``~/.config/systemd/user/``
> [!IMPORTANT]  
> Installing it as a userspace service is required for notifications to be sent correctly. If you install it as a system service, it will not work!
- Enable and/or start the service with ``systemctl --user enable xsnotifydaemon.service`` and ``systemctl --user start xsnotifydaemon.service``
