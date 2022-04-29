'Miranda Breves
'RCET0265
'Spring 2022
'Stan's Grocery App
'https://github.com/MEBreves/StansGrocery

Option Strict On
Option Explicit On

Imports System.ComponentModel
Imports System.Text.RegularExpressions

Public Class StansGroceryForm

    'Declaring global variables
    Dim food(,) As String
    Dim filterComboBoxAisleItems() As String = New String() _
                    {"Show All", "Aisle 1", "Aisle 2", "Aisle 3", "Aisle 4", "Aisle 5", "Aisle 6", "Aisle 7", "Aisle 8",
                     "Aisle 9", "Aisle 10", "Aisle 11", "Aisle 12", "Aisle 13", "Aisle 14", "Aisle 15"}

    Dim filterComboBoxCategoryItems() As String = New String() _
                    {"Fresh Vegetables", "Fresh Fruit", "Frozen", "Condiments / Sauces", "Various groceries", "Canned foods",
                     "Spices & herbs", "Dairy", "Cheese", "Meat", "Seafood", "Beverages", "Baked goods", "Baking", "Snacks",
                     "Themed meals", "Baby stuff", "Pets", "Personal care", "Pharmacy", "Kitchen", "Cleaning products",
                     "Office supplies", "Other stuff"}

    'Setting up form initially for user
    Private Sub StansGroceryForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Declaring variables
        Dim sortingList As List(Of String)

        'Populating the food array with the items from Grocery.txt, similar to a database
        LoadGroceryItems()

        'Setting control defaults for the form; the radio buttons and combo box are set
        FilterByAisleRadioButton.Checked = True
        FilterByCategoryRadioButton.Checked = False
        FilterComboBox.Items.AddRange(filterComboBoxAisleItems)
        FilterComboBox.SelectedItem = FilterComboBox.Items.Item(0)

        'Adding tooltips to Text boxes and buttons
        MainToolTip.SetToolTip(SearchTextBox, "Find your item by typing its name. Please do not include numbers.")
        MainToolTip.SetToolTip(SearchButton, "Click to search for your item in the display.")
        MainToolTip.SetToolTip(FilterByAisleRadioButton, "Sets the filter options to aisle numbers.")
        MainToolTip.SetToolTip(FilterByCategoryRadioButton, "Sets the filter options to category sections.")
        MainToolTip.SetToolTip(FilterComboBox, "Filter the display by selecting from an aisle or section.")
        MainToolTip.SetToolTip(DisplayListBox, "Click an item to see the aisle number and section.")
        MainToolTip.SetToolTip(DisplayLabel, "View the item's aisle number and section when you click it in the display.")


        'Sorting filter combo box category items alphabetically using a list (easier than an array)
        sortingList = filterComboBoxCategoryItems.ToList()
        sortingList.Sort()                  'The array variable has a sort function, but it does not have an insert.
        sortingList.Insert(0, "Show All")   'Insert makes it easy to add an item to the list at any location
        filterComboBoxCategoryItems = sortingList.ToArray()     'The category items array is then filled with the formatted list.

        'The list box normally repaints itself every time an item is added. As multiple items are to be added, the update
        'method will only allow the list box to repaint itself once.
        DisplayListBox.BeginUpdate()
        'Adding all of the items to the display box by looping thorugh the food array
        For i As Integer = 0 To CInt(food.Length / 3) - 1
            DisplayListBox.Items.Add(food(i, 0))    'Each food item name is added to the Display List Box
        Next
        DisplayListBox.EndUpdate()

    End Sub

    Private Sub StansGroceryForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        SplashScreenForm.Close()    'The splash screen is still open, but hidden. It needs to be closed.
    End Sub


    ' ===========================================  Form Object Handling  =================================================

    Private Sub SearchButton_Click(sender As Object, e As EventArgs) Handles SearchButton.Click,
        SearchContextToolStripItem.Click, SearchMenuToolStripItem.Click

        'Declaring variables
        Dim stringSpacePattern As String = "^[A-Za-z\s]+$"
        Dim regex As Regex = New Regex(stringSpacePattern)

        If SearchTextBox.Text = "zzz" Then      'This is a method for the user to quit the program

            'Immediately exit program
            Me.Close()

        Else
            'Setting the Radio buttons and filter combo box to their default values 
            FilterByAisleRadioButton.Checked = True
            FilterByCategoryRadioButton.Checked = False
            FilterComboBox.Items.Clear()                                'Clearing the current Filter Box items
            FilterComboBox.Items.AddRange(filterComboBoxAisleItems)     'Setting the Aisle values to the combo box
            FilterComboBox.SelectedItem = FilterComboBox.Items.Item(0)  'Setting "Show All" to be automatically selected

            'Searchbox.txt is evaluated to check for numbers or weird characters
            If Not regex.IsMatch(SearchTextBox.Text) Then
                MsgBox("The name of the items you were trying to find was invalid. Please search for an item without using " &
                       "numbers.", , "Search Error")
                Exit Sub           'If a strange character / number was found, only show message box and don't filter.
            End If

            'If the Search box text was valid, filter the items in the display box and show them to the user.
            FilterItems()

        End If

    End Sub

    Private Sub FilterRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles _
            FilterByAisleRadioButton.CheckedChanged, FilterByCategoryRadioButton.CheckedChanged

        FilterComboBox.Items.Clear()        'Removing the current values from the filter combo box.

        Select Case True
            Case FilterByAisleRadioButton.Checked           'If the aisle button was checked, fill the box with aisle options
                FilterComboBox.Items.AddRange(filterComboBoxAisleItems)
            Case FilterByCategoryRadioButton.Checked        'If the category button was checked, fill the box with categories
                FilterComboBox.Items.AddRange(filterComboBoxCategoryItems)
        End Select

        'Set the first item ("Show All") as the default value in the combo box.
        FilterComboBox.SelectedItem = FilterComboBox.Items.Item(0)

    End Sub

    Private Sub FilterComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles _
            FilterComboBox.SelectedIndexChanged

        'If the user selects an option in the combo box, filter the displayed items in the list box by the filter value.
        FilterItems()

    End Sub

    Private Sub DisplayListBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DisplayListBox.SelectedIndexChanged

        'Declaring variables
        Dim foodName, aisleNumber, sectionName As String

        'Preventing array errors by checking if the display box selected item index is 0 or greater.
        If DisplayListBox.SelectedIndex > -1 Then

            'The item that has been selected is the item / food name
            foodName = DisplayListBox.Items.Item(DisplayListBox.SelectedIndex).ToString

            'To find the associated aisle and category of the item, the food array is searched
            For i As Integer = 0 To CInt(food.Length / 3) - 1
                If food(i, 0) = foodName Then
                    aisleNumber = food(i, 1)
                    sectionName = food(i, 2)
                    Exit For      'Once the item has been found, stop searching the food array to save time.
                End If
            Next

            'Display the item's aisle number and category to the user so they can find it in the store
            'If the item ends with 's', it is probably plural, so describe the item as a plural noun instead of singular
            If Strings.Right(foodName, 1) = "s" Then
                DisplayLabel.Text = $"The {foodName} are on Aisle {aisleNumber} in the {sectionName} section."
            Else
                DisplayLabel.Text = $"The {foodName} is on Aisle {aisleNumber} in the {sectionName} section."
            End If

        End If

    End Sub

    Private Sub Exit_Procedure(sender As Object, e As EventArgs) Handles ExitMenuToolStripItem.Click,
            ExitContextToolStripItem.Click
        Me.Close()      'If any method of exiting control is selected, close the form.
    End Sub

    Private Sub AboutMenuToolStripItem_Click(sender As Object, e As EventArgs) Handles AboutMenuToolStripItem.Click
        AboutForm.Show()    'If the user clicks the About button in the File Menu, display the About page form.
    End Sub


    ' =========================================  Subs Called By Form Objects  ============================================

    Sub LoadGroceryItems()

        'Declaring variables
        Const fileNumber As Integer = 1                     'This needs to be at least one or an error is thrown
        Dim currentLine = "", recordsString = ""
        Dim midLength = 0, count = 0
        Dim itemName, aisleNumber, category, temp() As String
        Dim organizingTable As New Data.DataTable
        Dim dataStyle As DataView

        'A data table format will be used in order to sort a multi-dimensional data set. Lists or arrays cannot do this.
        'The data table has headers for its columns to organize it; there will be three columns called name, aisle, and category.
        organizingTable.Columns.Add("Name", GetType(String))
        organizingTable.Columns.Add("Aisle", GetType(String))
        organizingTable.Columns.Add("Category", GetType(String))

        'Preventing program crash by using a try-catch
        Try

            'Opening the Grocery.txt file and assigning it to the file number (1) to be read
            FileOpen(fileNumber, "../../../Grocery.txt", OpenMode.Input)

            'Reading contents from the file to a long string (recordsString)
            Do Until EOF(fileNumber)         'EOF stands for end of file - basically read until the end of the file
                Input(fileNumber, currentLine)      'Setting the value of the line to the currentLine variable
                recordsString += currentLine        'The currentLine variable string is added to the resultsString
            Loop

            'When all records are read, close the file
            FileClose(fileNumber)
            temp = Split(recordsString, "$$ITM")    'Creating an array from the long string using the "$$ITM" seperator

            'Filling the data table while checking for bad data
            For i As Integer = 0 To temp.Length - 1

                'This will check if the aisle number of the food item is present. If the length is 0, there is no aisle
                'number and this is an incomplete item entry (bad data).
                midLength = InStr(temp(i), "%%CAT", CompareMethod.Text) - (InStr(temp(i), "##LOC", CompareMethod.Text) + 5)

                If midLength > 0 Then
                    itemName = CStr(Split(temp(i), "##LOC")(0))     'Get the name up to the "##LOC" identifier
                    'Get the aisle number from the "##LOC" identifier index to the midLength index
                    aisleNumber = Mid(temp(i), InStr(temp(i), "##LOC", CompareMethod.Text) + 5, midLength)
                    category = Split(temp(i), "%%CAT")(1)   'Get the category name after the "%%CAT" identifier
                Else
                    Continue For        'If the midlength was 0 (no aisle value), skip this iteration of the for loop
                End If

                'If the aisle number was present, the item name and category still need to be checked to only record good data
                If itemName.Length > 0 And aisleNumber.Length > 0 And category.Length > 0 Then
                    organizingTable.Rows.Add(itemName, aisleNumber, category)
                End If

            Next

            dataStyle = organizingTable.DefaultView           'Finalizing the data table into a default view
            dataStyle.Sort = "Name ASC"                       'Sorting multidimensional data so nothing is lost
            ReDim food(organizingTable.Rows.Count - 1, 2)     'setting the foodItems array size to hold all grocery values

            organizingTable = dataStyle.ToTable()             'Placing the sorted values back into the table

            'Moving the data from the data table to the food array
            'This array method (array.foreach) iterates through each item in the given array and applies a simple function
            'to that item. There are two array.foreach methods here to populate the food array with an array of 3 values (name,
            'aisle, and category) per actual item (247 entries).
            Array.ForEach(Enumerable.Range(0, 3).ToArray,
                          Sub(x) Array.ForEach(Enumerable.Range(0, organizingTable.Rows.Count).ToArray,
                          Sub(y) food(y, x) = CStr(organizingTable.Rows(y).Item(x))))

        Catch fileNotFound As IO.FileNotFoundException
            MsgBox(fileNotFound.Message)        'Catch missing file error and display it to the user

        Catch badFileName As IO.IOException
            MsgBox(badFileName.Message)         'Catch a file name error and display it to the user

        Catch ex As Exception
            MsgBox(ex.Message)                  'Catch any other type of error and display it to the user

        End Try

    End Sub

    Sub FilterItems()

        'Declaring variables
        Dim foodList As New List(Of String)
        Dim filterType As Integer
        Dim filterSelection As String

        'Filling the foodList with the item names in the global food array
        For i As Integer = 0 To CInt(food.Length / 3) - 1
            foodList.Add(food(i, 0))
        Next

        filterSelection = FilterComboBox.SelectedItem.ToString      'Getting the selected option from the combo box
        DisplayListBox.Items.Clear()                                'Clearing the Display List Box

        'The list box normally repaints itself every time an item is added. As multiple items are to be added, the update
        'method will only allow the list box to repaint itself once.
        DisplayListBox.BeginUpdate()
        If FilterComboBox.SelectedItem.ToString = "Show All" Then

            'When the Combo box contains "Show All", filter by any text in the search text box or put all items in the
            'Display List Box
            If SearchTextBox.Text.Trim <> "" Then       'Checking if the Search Text Box contains text and filtering by that
                For i As Integer = 0 To foodList.Count - 1
                    If (InStr(food(i, 0), SearchTextBox.Text, CompareMethod.Text) > 0) Then
                        DisplayListBox.Items.Add(foodList.Item(i))
                    End If
                Next
            Else                                        'If there wasn't any user text, add all items to display list box
                For i As Integer = 0 To foodList.Count - 1
                    DisplayListBox.Items.Add(foodList.Item(i))
                Next
            End If
        Else                    'If the filter item wasn't "Show All", filter the data by aisle or by category
            Select Case True
                Case FilterByAisleRadioButton.Checked       'The Aisle Radio button is selected
                    filterType = 1
                    filterSelection = LTrim(Strings.Right(filterSelection, 2))  'Getting just the number, not "Aisle #"
                Case FilterByCategoryRadioButton.Checked    'The Category Radio button is selected
                    filterType = 2
            End Select

            'If the user wrote something in the search text box, that needs to be a filter criteria as well.
            If SearchTextBox.Text.Trim <> "" Then

                For i As Integer = 0 To foodList.Count - 1
                    If (food(i, filterType) = filterSelection) And      'Checking if the aisle/category matches
                        (InStr(food(i, 0), SearchTextBox.Text, CompareMethod.Text) > 0) Then    'Checking if the user text is part of the item name

                        DisplayListBox.Items.Add(foodList.Item(i))
                    End If
                Next

            Else        'There was no text in the Search Text Box, so the items are only filtered by the aisle/category

                For i As Integer = 0 To foodList.Count - 1
                    If food(i, filterType) = filterSelection Then
                        DisplayListBox.Items.Add(foodList.Item(i))
                    End If
                Next

            End If

        End If
        DisplayListBox.EndUpdate()

    End Sub

End Class
