# Hawks-And-Doves
Hawks and Dove Game Simulation in Unity 3D

* The application contains a Graphical User Interface which takes a set number of parameters and simulates Hawks, Doves and Food. 
* At each iteration the application performs a set of tasks like gathering food for example.
* It keeps track of the number of Hawks, Doves, Food and either eliminates or reproduces Hawks and Doves based on a threshold.
* The simulation is created using custom sphere materials for Hawks, Doves and Food. The elimination and reproduction are then 
  displayed on the center panel of the GUI.
  
  Run Steps:
  * Navigate to Builds folder and find HawksAndDoves2D.
  * Run HawksAndDoves2D.
  * Enter the values in the text field and start the simulation
  * The results can be tracked in the sine wave graphs.
  * The results are also stored in Builds/HawksAndDove2D_Data/ as CSV.
  * It is a bit slow for large values of Hawks and Doves, this is due to CSV file generation.
  * Make sure to provide smaller values.
