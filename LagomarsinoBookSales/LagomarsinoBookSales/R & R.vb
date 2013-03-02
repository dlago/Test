Option Strict On
'Derrick Lagomarsino 


Public Class Form1

    'Declare Constant
    Const DISCOUNT_RATE As Decimal = 0.1D
    Private TotalBooks As Integer
    Private TotalSales As Decimal
    Private NumberOfSales As Integer


    Private Sub ExitButton_Click(sender As System.Object, e As System.EventArgs) Handles ExitButton.Click
        'Exit Program
        Me.Close()
    End Sub

    Private Sub CalculateButton_Click(sender As System.Object, e As System.EventArgs) Handles CalculateButton.Click

        Dim Quantity As Integer
        Dim Price As Decimal
        Dim ExtendedPrice As Decimal
        Dim Discount As Decimal
        Dim DiscountedPrice As Decimal
        Dim AverageSale As Decimal

        'Do calculations
        Try
            Quantity = Integer.Parse(QuantityTextBox.Text)
            Try
                Price = Decimal.Parse(PriceTextBox.Text)
                ExtendedPrice = Quantity * Price
                Discount = ExtendedPrice * DISCOUNT_RATE
                DiscountedPrice = ExtendedPrice - Discount

                'Accumulate totals
                TotalBooks += Quantity
                TotalSales += DiscountedPrice
                NumberOfSales += 1
                AverageSale = TotalSales / NumberOfSales


                'Display Results
                ExtendedPriceTextBox.Text = ExtendedPrice.ToString("C")
                DiscountTextBox.Text = "-" + Discount.ToString()
                DiscountTotalTextBox.Text = DiscountedPrice.ToString("C")

                'Display summary
                TotalBooksTextBox.Text = TotalBooks.ToString()
                TotalSalesTextBox.Text = TotalSales.ToString("C")
                AverageTextBox.Text = AverageSale.ToString("C")


            Catch formatEx As FormatException
                MessageBox.Show("Price must be a decimal", "Data Entry Error", MessageBoxButtons.OK)

                PriceTextBox.Focus()
                PriceTextBox.SelectAll()

            End Try

        Catch ex As FormatException
            MessageBox.Show("Quantity must be an integer", "Data Entry Error", MessageBoxButtons.OK)

            QuantityTextBox.Focus()
            QuantityTextBox.SelectAll()

        Catch otherex As Exception
            MessageBox.Show("Unknown Error")
        End Try

    End Sub

    Private Sub ClearButton_Click(sender As System.Object, e As System.EventArgs) Handles ClearButton.Click
        QuantityTextBox.Text = ""
        TitleTextBox.Text = ""
        PriceTextBox.Text = ""
        ExtendedPriceTextBox.Text = ""
        DiscountTextBox.Text = ""
        DiscountTotalTextBox.Text = ""
        QuantityTextBox.Focus()

    End Sub

   
    Private Sub QuantityTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuantityTextBox.TextChanged

    End Sub
End Class
