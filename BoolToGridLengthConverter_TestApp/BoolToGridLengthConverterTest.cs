using System;
using Windows.UI.Xaml;
using Xunit;

namespace Net.Habashi.Uwp.Converter
{
    public class BoolToGridLengthConverterTest
    {
        private BoolToGridLengthConverter boolToGridLengthConverter = new BoolToGridLengthConverter();

        [Fact]
        public void TestBindingValueFalseReturnPixelParam()
        {
            var result = this.boolToGridLengthConverter.Convert(true, typeof(GridLength), "42", "");
            Assert.Equal(new GridLength(42, GridUnitType.Pixel), result);
        }

        [Fact]
        public void TestBindingValueFalseReturnAutoParam()
        {
            var result = this.boolToGridLengthConverter.Convert(true, typeof(GridLength), "Auto", "");
            Assert.Equal(new GridLength(1, GridUnitType.Auto), result);
        }

        [Fact]
        public void TestBindingValueFalseReturnStarParam()
        {
            var result = this.boolToGridLengthConverter.Convert(true, typeof(GridLength), "12*", "");
            Assert.Equal(new GridLength(12, GridUnitType.Star), result);
        }

        [Fact]
        public void TestBindingValueTrueParamNotGiven()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                this.boolToGridLengthConverter.Convert(true, typeof(GridLength), null, "");
            });
        }

        [Fact]
        public void TestBindingValueFalse()
        {
            var result = this.boolToGridLengthConverter.Convert(false, typeof(GridLength), "1", "");
            Assert.Equal(new GridLength(0), result);
        }

        [Fact]
        public void TestBindingValueNotBool()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.boolToGridLengthConverter.Convert("true", typeof(GridLength), "0", "");
            });
        }

        [Fact]
        public void TestBindingValueNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                this.boolToGridLengthConverter.Convert(null, typeof(GridLength), "0", "");
            });
        }

        [Fact]
        public void TestGridLengthToBoolNotImplemented()
        {
            Assert.Throws<NotImplementedException>(() =>
            {
                this.boolToGridLengthConverter.ConvertBack(null, null, null, null);
            });
        }
    }
}
