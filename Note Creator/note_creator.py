import io
import time

# Code to read input without having to press Enter
# Not my code
# Code found here http://code.activestate.com/recipes/134892/
class _Getch:
    """Gets a single character from standard input.  Does not echo to the
screen."""
    def __init__(self):
        try:
            self.impl = _GetchWindows()
        except ImportError:
            self.impl = _GetchUnix()

    def __call__(self): return self.impl()


class _GetchUnix:
    def __init__(self):
        import tty, sys

    def __call__(self):
        import sys, tty, termios
        fd = sys.stdin.fileno()
        old_settings = termios.tcgetattr(fd)
        try:
            tty.setraw(sys.stdin.fileno())
            ch = sys.stdin.read(1)
        finally:
            termios.tcsetattr(fd, termios.TCSADRAIN, old_settings)
        return ch


class _GetchWindows:
    def __init__(self):
        import msvcrt

    def __call__(self):
        import msvcrt
        return msvcrt.getch()


getch = _Getch()


# Start of my code

# Get the file that you want to write to from the user
file_name = raw_input('Enter File to write to: ')

# Open the passed file
note_file = open(file_name, 'w')

# Get ready to accept input
print('Press S to start')
note = getch()

print('You have started to end press S again')

while 1:

    # Convert the time returned from seconds to milliseconds
    time1 = int(round(time.time() * 1000))

    note = getch()

    # Check to see if you are done
    if note.upper() == 'S':
        break

    # Convert the time returned from seconds to milliseconds
    time2 = int(round(time.time() * 1000))

    # Write the inputted char to the file as well as the milliseconds between inputs
    note_file.write(note + ' ')
    note_file.write('%d' % (time2 - time1))
    note_file.write('\n')

print('Exiting')

# Close the File used
note_file.close()
