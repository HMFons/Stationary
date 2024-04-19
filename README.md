# Stationary
Create a stationary tcx file from fitbit heartrate data for use with Intervals.icu

## Need
I have loads of issues keeping my GPS connected while tracking an excercise with my fitbit. Often it isn't that big of a problem. The location recording will crap out, but the heartrate data is saved. As long as the tcx has any location data, the session is fine.
What doesn't work is when the connection is lost at the start of the session.
This can of course also be used to upload workouts where GPS wasn't active or usefull. Treadmill, pool or stationary bikes for example.

## Method
Grab your heartrate data from the fitbit dashboard. The call looks something like this.
https://web-api.fitbit.com/1.1/user/-/activities/heart/date/*yyyy-MM-dd*/*yyyy-MM-dd*/1sec/time/*hh:mm:ss*/*hh:mm:ss*.json

Save it as a json and when prompted provide the filename.
The app also needs a location to put you, in the format of latitude and longitude degrees.