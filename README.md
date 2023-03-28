[![NuGet Version](https://img.shields.io/nuget/v/Drastic.LookinServer.svg)](https://www.nuget.org/packages/Drastic.LookinServer/) ![License](https://img.shields.io/badge/License-MIT-blue.svg)

# Drastic.LookinServer


Drastic.LookinServer is a .NET iOS library that integrates LookinServer, a component of Lookin: An iOS UI Debugging tool. Lookin lets you inspect and debug iOS UI Controls from your Mac, similar to a service like Reveal, but it's open source.

To inspect your app, you need LookinServer installed as a component, generally done with Cocoapods inside your Xcode project. Adding the framework is tricky for .NET developers, so this nuget simplifies the process.

## Setup

- Install the `Drastic.LookinServer` nuget.
- Launch your iOS app.
- It should now appear in the [Lookin](https://lookin.work/) app.