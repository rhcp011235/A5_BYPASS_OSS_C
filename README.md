# A5 - iOS Device Activation Bypass Tool

A professional Windows desktop application for iOS device activation bypassing using the checkm8 exploit. Built with C# Windows Forms, featuring a modern UI and robust device management capabilities.

![License](https://img.shields.io/badge/License-Proprietary-orange)
![.NET Framework](https://img.shields.io/badge/.NET-4.8-blue)
![Platform](https://img.shields.io/badge/Platform-Windows-lightgrey)

## Overview

A5 is a sophisticated tool designed to bypass iOS device activation locks. The application provides a user-friendly interface for:

- Automatic device detection and connection management
- Comprehensive device information retrieval (UDID, model, iOS version, IMEI, ECID)
- Compatibility checking via checkm8 exploit
- Secure activation bypass process
- Real-time progress monitoring and logging

## Features

- **Smart Device Detection**: Automatic USB device detection with 3-second polling intervals
- **Device Information**: Retrieves detailed device data including:
  - Unique Device ID (UDID)
  - Model identification (supports all iPhone, iPad, and iPod models)
  - iOS version and build number
  - Activation state
  - IMEI and ECID
  - Serial number and region info
- **Activation Bypass**: Complete workflow for bypassing iOS activation locks
- **Modern UI**: Sleek interface with Guna UI2 components, blur effects, and custom theming
- **Security Monitoring**: Process monitoring to detect interference
- **Logging System**: Detailed timestamped logs with color-coded severity levels
- **Single Instance**: Ensures only one instance of the application runs

## Requirements

### System Requirements
- Windows 10/11 (64-bit recommended)
- .NET Framework 4.8
- Administrator privileges (required for device communication)
- USB 2.0 or 3.0 port

### Software Dependencies
- [iTunes](https://www.apple.com/itunes/) (latest version)
- [3uTools](http://www.3u.com/) (for device drivers)

### Supported Devices
The application supports all devices compatible with the checkm8 exploit, including:
- iPhone 4s through iPhone 16 series
- iPad 2 through iPad Pro (M5)
- iPad Air (through M3)
- iPad mini (through A17 Pro)
- iPod Touch 5th Generation

## Installation

1. Install iTunes from the official Apple website
2. Install 3uTools for device driver support
3. Download the latest A5 release
4. Extract to a permanent location
5. Run `A5.exe` as Administrator

## Usage

1. **Connect Device**: Connect your iOS device via USB cable
2. **Trust Computer**: Unlock your device and tap "Trust" when prompted
3. **Device Detection**: The application automatically detects and displays device info
4. **Compatibility Check**: Click "Check Device" to verify checkm8 compatibility
5. **Activate**: If supported, proceed with the activation bypass process
6. **Restart**: The device will restart automatically after activation

## Architecture

### Project Structure

```
A5_BYPASS_OSS_C/
├── SpiderPRO/              # Main application code
│   ├── Form1.cs           # Main window and device management
│   ├── Form2.cs           # Custom message dialogs
│   ├── Program.cs         # Application entry point
│   ├── ProcessMonitor.cs  # Security monitoring
│   ├── DeviceData.cs      # Device information model
│   ├── Dropshadow.cs      # Custom window effects
│   └── Win32.cs           # Win32 interop definitions
├── win-x64/               # 64-bit native libraries
├── win-x86/               # 32-bit native libraries
├── OTA/                   # Over-the-air update packages
├── Properties/            # Application resources
└── Resources/             # Icons and media assets
```

### Key Components

- **Form1**: Main application window handling device detection, activation workflow, and user interface
- **Form2**: Modern message dialog with blur effects and custom theming
- **ProcessMonitor**: Background service monitoring for interfering processes
- **Native Libraries**: libimobiledevice tools (idevice_id, ideviceinfo, idevicediagnostics, afcclient)

### External Dependencies

| Package | Version | Purpose |
|---------|---------|---------|
| Guna.UI2.WinForms | 2.0.4.7 | Modern UI components |
| Newtonsoft.Json | 13.0.4 | JSON serialization |
| VMProtect.SDK | 1.0.0 | Application protection |
| Obfuscar | 2.2.50 | Code obfuscation |
| System.Net.Http | 4.3.4 | HTTP client operations |

## Technical Details

### Device Communication

The application uses libimobiledevice Windows builds for device communication:

- **idevice_id**: Retrieves connected device UDIDs
- **ideviceinfo**: Fetches comprehensive device information
- **idevicediagnostics**: Performs device operations (restart, mobilegestalt)
- **afcclient**: Transfers files to device filesystem

### Activation Workflow

1. Verify device connection and retrieve UDID
2. Check device compatibility via remote API
3. Transfer activation payload to device (/Downloads/downloads.28.sqlitedb)
4. Restart device (first attempt)
5. Verify activation status via mobilegestalt
6. Restart device (second attempt)
7. Confirm successful activation

### Security Features

- Single instance mutex protection
- Administrator privilege requirement
- Process termination monitoring
- Secure TLS 1.2/1.3 connections
- Certificate validation bypass for local operations

## Building

### Prerequisites
- Visual Studio 2019 or later
- .NET Framework 4.8 Development Tools
- NuGet package restore enabled

### Build Steps

1. Open `SpiderPRO.sln` in Visual Studio
2. Restore NuGet packages
3. Configure build target (x86 or x64)
4. Build solution

### Output

Build artifacts are generated in:
- `bin/Debug/` or `bin/Release/` (development)
- Packaged with native libraries in `win-x64/` or `win-x86/`

## Logging

The application maintains detailed logs with timestamped entries:

```
[HH:mm:ss] Device connected: <udid>
[HH:mm:ss] Model: iPhone 6s, iOS: 12.5.7, Activation: Activated
[HH:mm:ss] Progress: 60% - Restarting your device, please wait...
```

Log levels are color-coded:
- **Black**: General information
- **Blue**: Progress updates
- **Green**: Success messages
- **Orange**: Warnings
- **Red**: Errors

## Troubleshooting

### Common Issues

**Device Not Detected**
- Ensure iTunes and 3uTools are installed
- Try different USB cable or port
- Restart the application
- Check Windows Device Manager for device recognition

**Activation Failed**
- Verify device is checkm8 compatible
- Ensure stable USB connection
- Device must have Wi-Fi enabled
- Try multiple restart attempts
- Check logs for specific error messages

**Version Check Failed**
- Verify internet connection
- Check firewall settings
- Ensure TLS 1.2 is enabled

## License

This project is proprietary software. All rights reserved.

## Disclaimer

This tool is intended for educational and legitimate device recovery purposes only. Users are responsible for ensuring they have legal rights to activate the device in question. The developers assume no liability for misuse.

## Credits

- [libimobiledevice](https://github.com/libimobiledevice/libimobiledevice) - Cross-platform protocol library
- [Guna UI](https://gunaui.com/) - Modern Windows Forms UI library
- [Newtonsoft.Json](https://www.newtonsoft.com/json) - JSON framework for .NET
