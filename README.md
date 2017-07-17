# UwpBoolToGridLengthConverter
UWP Converter for Boolean values in GridLength values

# Usage
1. Add namespace to xaml-page:
```xaml
<Page
  ...
  xmlns:bool2gridLengthConverter="using:Net.Habashi.Uwp.Converter.BoolToGridLengthConverter"
  ...
  />
```

2. Add BoolToGridLengthConverter to Static-Resources:
```xaml
<Page.Resources>
    <bool2gridLengthConverter:BoolToGridLengthConverter x:Key="BoolToGridLengthConverter"/>
</Page.Resources>
```

3. Use the converter:
```xaml
<Grid.RowDefinitions>
    <RowDefinition Height="{Binding IsAbleToCall, Converter={StaticResource BoolToGridLengthConverter}, ConverterParameter=1*}"/>
</Grid.RowDefinitions>
```

# Development
Build with Visual Studio, Test with xUnit.
