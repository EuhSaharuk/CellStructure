from Window import *
import sys

if __name__ == "__main__":
    root = Tk()
    window = Window(root)
    window.pack(side="top", fill="both", expand=True)
    window.set_params(sys.argv[1:])
    root.mainloop()
