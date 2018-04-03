To run note_creator in command line

	python note_creator.py

It will ask to pass a file name pass in the following format

	(filename).txt
	ex: song_test.txt

Then you press S to start. Pressing S will immediately start recording input after that point

Press the notes you want to map until done

When done press S again to stop recording input

The file you specified will now have the following format

	(key pressed) (time between that key being pressed and the last key)

	where time is in milliseconds

The time value is what should be used as the time seperation of the notes
i.e. Note2 should hit the bottom X milliseconds after Note1. Where X is the time recorded after Note2