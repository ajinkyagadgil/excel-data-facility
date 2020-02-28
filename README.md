# excel-data-facilities
The desktop application inputs a CSV file having seller products list which has 'Available Inventory' column and outputs the data which have inventory less than the entered value of 'Available Inventory' to a CSV file.

1. Enter the value which is for the 'Available Inventory' value below which you need the list of products.
2. Browse for CSV file of product listing along with inventory details.
3. Clicking import parses entire CSV file and filters the data which have 'Available Inventory' column values less than the selected value and outputs the CSV file in output folder filtering the data.
4. This software was for CSV files given in specific formats. 
5. Used Nlog for logging purpose and stored the logs in program data.
6. This software is used by Seller to avoid repeatative steps everyday in excel to filter the column based on a value.
7. This minimizes the repeatative work and saves time and keep every export records for future reference and doesnt need to safe filtered excel everytime.
