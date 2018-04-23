using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace MiniMapProperties {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void ValidationError(object sender, ValidationErrorEventArgs e) {
            if (e.Action == ValidationErrorEventAction.Added)
                MessageBox.Show(e.Error.ErrorContent.ToString());
        }
    }

    public class PositiveDoubleValidationRule : ValidationRule {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo) {
            double val;
            if (Double.TryParse(value as string, NumberStyles.Number, cultureInfo, out val)) {
                if (val <= 0) return new ValidationResult(false, "Input value should be larger than 0.");
                return new ValidationResult(true, null);
            }
            return new ValidationResult(false, "Input value should be floating point number.");
        }
    }
}
