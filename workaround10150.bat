set directory1="WebViewInterop\bin\x64\Debug\net8.0-android"
if not exist "%directory1%" mkdir "%directory1%"
xcopy WebViewInterop\bin\x64\Debug\net8.0-android\*.* WebViewInterop\bin\x64\Debug\net8.0-android\android-x64\*.* /Y /C
set directory2="WebViewInterop\bin\x64\Debug\net8.0-windows10.0.19041.0\"
if not exist "%directory2%" mkdir "%directory2%"
xcopy WebViewInterop\bin\x64\Debug\net8.0-windows10.0.19041.0\*.* WebViewInterop\bin\x64\Debug\net8.0-windows10.0.19041.0\win-x64\*.* /Y /C
set directory3="WebViewInterop\obj\x64\Debug\net8.0-windows10.0.19041.0\win-x64"
if not exist "%directory3%" mkdir "%directory3%"
xcopy WebViewInterop\obj\x64\Debug\net8.0-windows10.0.19041.0\webviewinterop.* WebViewInterop\obj\x64\Debug\net8.0-windows10.0.19041.0\win-x64\webviewinterop.* /Y /C
set directory3="WebViewInterop\obj\x64\Debug\net8.0-windows10.0.19041.0\win-x64\ref"
if not exist "%directory3%" mkdir "%directory3%"
xcopy WebViewInterop\obj\x64\Debug\net8.0-windows10.0.19041.0\ref\webviewinterop.* WebViewInterop\obj\x64\Debug\net8.0-windows10.0.19041.0\win-x64\ref\webviewinterop.* /Y /C


set directory1="WebViewInterop\bin\x64\release\net8.0-android"
if not exist "%directory1%" mkdir "%directory1%"
xcopy WebViewInterop\bin\x64\release\net8.0-android\*.* WebViewInterop\bin\x64\release\net8.0-android\android-x64\*.* /Y /C
set directory2="WebViewInterop\bin\x64\release\net8.0-windows10.0.19041.0\"
if not exist "%directory2%" mkdir "%directory2%"
xcopy WebViewInterop\bin\x64\release\net8.0-windows10.0.19041.0\*.* WebViewInterop\bin\x64\release\net8.0-windows10.0.19041.0\win-x64\*.* /Y /C
set directory3="WebViewInterop\obj\x64\release\net8.0-windows10.0.19041.0\win-x64"
if not exist "%directory3%" mkdir "%directory3%"
xcopy WebViewInterop\obj\x64\release\net8.0-windows10.0.19041.0\webviewinterop.* WebViewInterop\obj\x64\release\net8.0-windows10.0.19041.0\win-x64\webviewinterop.* /Y /C
set directory3="WebViewInterop\obj\x64\release\net8.0-windows10.0.19041.0\win-x64\ref"
if not exist "%directory3%" mkdir "%directory3%"
xcopy WebViewInterop\obj\x64\release\net8.0-windows10.0.19041.0\ref\webviewinterop.* WebViewInterop\obj\x64\release\net8.0-windows10.0.19041.0\win-x64\ref\webviewinterop.* /Y /C

