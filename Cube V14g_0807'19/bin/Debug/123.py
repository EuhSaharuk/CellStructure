from tkinter import *
import sys

FONT = "Arial 10"

app = Tk()
app.title("Многоугольник")
#app.minsize(800, 400)
app.resizable(False, False)
text = Text(app, width=40, heigh=15)
text.pack()
text.insert(1.0, sys.argv)
print(sys.argv[1:])
print(sys.argv)
app.mainloop()