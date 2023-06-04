# elevatorchallenge

At this point, the app supports works like this: Upon starting the app some external configurations are read from file app.config. When reading these values, they are compared to some constants embedded in the app(e.g to check that say a floor has at least 0 persons and not a negative number of people).
These configurations are number of elevators, number of floors, maximum people on floor and elevator weight limit. Currently all have the default value of 10. The constants are: the minimum number of elevators( = 1), the minimum number of floors( = 1), the minimum number of people on the floor (= 0) and the minimum elevator weight limit(= 1).

Elevators are being bootstraped in a list. As part of this bootstrapping, a random number set between 0 and the elevator weight limit is assigned to the elevator as the people count. So is a current floor assigned between 1 and the number of floors set in the configurations file. Also the elevator status is randomly set between going up and going down.

Floors are being bootstrepped in a similar fashion, with the number of people on each floor being randomly assigned between 0 and the maximum people on floor. The number of people on each floor can be set by the user afterwards, this being one of the features of the console app.

# Features supported

1. Show elevator status. Shows the status of each elevator. The status includes the number of people in the elevator, the floor where the elevator currently is and if it's going up or going down.
2. Call elevator. Once selecting this option, the user needs to enter a floor. Once the floor is provided by the user, the elevator that is closest and still is below the maximum weight will be displayed. Before displaying the status of the elevator might be changed from going up to going down or viceversa if it's the case for that. Before accepting the calling floor provided by the user some checks are being done on it(bigger than 0 and smaller or equal to the number of existing floors).
3. Set number of people on each floor. Once selecting this feature, the user is prompted to supply the number of people on each floor. This number is also subject to being validated so it is between 0 and the maximum number of people on the floor as set in the initial configuration.

# Possible improvements
1. For the calling elevastor feature, the going up or going down status might get to be involved in determining the closest elevator. This also assumes that the person calling the elevator will tell if they intend to go up or down.
