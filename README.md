# XSNotifyDaemon

A C# daemon application that implements the XSOverlay WebSockets notification API and relays them to desktop notifications, without needing XSOverlay.

Intended to be used with Linux and wlxoverlay-s, to provide XSOverlay notifications in VR since XSOverlay is borked on Linux.

As of current, XSNotifyDaemon does not support the legacy TCP protocol in XSOverlay **nor** does it support Windows.  
