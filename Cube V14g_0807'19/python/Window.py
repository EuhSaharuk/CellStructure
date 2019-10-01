from tkinter import *
from BodyParameters import *
from Calculations import *


class Window(Frame):

    FONT = "Times_new_roman 10"
    body_length = 0
    body_height = 0
    body_width = 0
    body_params = None

    def __init__(self, app, *args, **kwargs):
        Frame.__init__(self, app, *args, **kwargs)
        self.parent = app

        app.title("N-угольник+")
        app.minsize(900, 350)
        app.resizable(False, False)

        lab1 = Label(app, text="Высота ячейки", font=self.FONT)
        lab1.place(x=10, y=15)

        lab2 = Label(app, text="Количество углов", font=self.FONT)
        lab2.place(x=10, y=65)

        lab3 = Label(app, text="Угол поворота", font=self.FONT)
        lab3.place(x=10, y=90)

        lab4 = Label(app, text="Часть от объёма (%)", font=self.FONT)
        lab4.place(x=10, y=115)

        lab6 = Label(app, text="Начало", font=self.FONT)
        lab6.place(x=150, y=40)
        lab7 = Label(app, text="Конец", font=self.FONT)
        lab7.place(x=250, y=40)
        lab8 = Label(app, text="Шаг", font=self.FONT)
        lab8.place(x=350, y=40)

        self.cell_high_input = Entry(app, width=10, validate="key", borderwidth=2)
        self.cell_high_input['validatecommand'] = (self.cell_high_input.register(self.test_val), '%P', '%d')
        self.cell_high_input.place(x=150, y=15)
        self.cell_high_input.insert(1, '15')

        self.number_of_angles_start_input = Entry(app, width=10, validate="key", borderwidth=2)
        self.number_of_angles_start_input['validatecommand'] = (self.number_of_angles_start_input.register(self.test_val), '%P', '%d')
        self.number_of_angles_start_input.place(x=150, y=65)
        self.number_of_angles_start_input.insert(1, "4")
        self.number_of_angles_end_input = Entry(app, width=10, validate="key", borderwidth=2)
        self.number_of_angles_end_input['validatecommand'] = (self.number_of_angles_end_input.register(self.test_val), '%P', '%d')
        self.number_of_angles_end_input.place(x=250, y=65)
        self.number_of_angles_end_input.insert(1, "4")
        self.number_of_angles_step_input = Entry(app, width=10, validate="key", borderwidth=2)
        self.number_of_angles_step_input['validatecommand'] = (self.number_of_angles_step_input.register(self.test_val), '%P', '%d')
        self.number_of_angles_step_input.place(x=350, y=65)
        self.number_of_angles_step_input.insert(1, "1")

        self.rotation_angle_start_input = Entry(app, width=10, validate="key", borderwidth=2)
        self.rotation_angle_start_input['validatecommand'] = (self.rotation_angle_start_input.register(self.test_val), '%P', '%d')
        self.rotation_angle_start_input.place(x=150, y=90)
        self.rotation_angle_start_input.insert(1, "0")
        self.rotation_angle_end_input = Entry(app, width=10, validate="key", borderwidth=2)
        self.rotation_angle_end_input['validatecommand'] = (self.rotation_angle_end_input.register(self.test_val), '%P', '%d')
        self.rotation_angle_end_input.place(x=250, y=90)
        self.rotation_angle_end_input.insert(1, "0")
        self.rotation_angle_step_input = Entry(app, width=10, validate="key", borderwidth=2)
        self.rotation_angle_step_input['validatecommand'] = (self.rotation_angle_step_input.register(self.test_val), '%P', '%d')
        self.rotation_angle_step_input.place(x=350, y=90)
        self.rotation_angle_step_input.insert(1, "0")

        self.part_of_volume_start_input = Entry(app, width=10, validate="key", borderwidth=2)
        self.part_of_volume_start_input['validatecommand'] = (self.part_of_volume_start_input.register(self.test_val), '%P', '%d')
        self.part_of_volume_start_input.place(x=150, y=115)
        self.part_of_volume_start_input.insert(1, "40")
        self.part_of_volume_end_input = Entry(app, width=10, validate="key", borderwidth=2)
        self.part_of_volume_end_input['validatecommand'] = (self.part_of_volume_end_input.register(self.test_val), '%P', '%d')
        self.part_of_volume_end_input.place(x=250, y=115)
        self.part_of_volume_end_input.insert(1, "40")
        self.part_of_volume_step_input = Entry(app, width=10, validate="key", borderwidth=2)
        self.part_of_volume_step_input['validatecommand'] = (self.part_of_volume_step_input.register(self.test_val), '%P', '%d')
        self.part_of_volume_step_input.place(x=350, y=115)
        self.part_of_volume_step_input.insert(1, "10")

        btn1 = Button(app, text="  Рассчитать  ", font=self.FONT)
        btn1.bind('<Button-1>', lambda event: self.calculate_button_click() )
        btn1.place(x=420, y=15)
        btn2 = Button(app, text="  Нарисовать  ", font=self.FONT)
        btn2.bind('<Button-1>', lambda event: ())
        btn2.place(x=420, y=55)
        btn3 = Button(app, text="     Удалить    ", font=self.FONT)
        btn3.bind('<Button-1>', lambda event: ())
        btn3.place(x=420, y=95)
        btn4 = Button(app, text=" Исследовать ", font=self.FONT)
        btn4.bind('<Button-1>', lambda event: ())
        btn4.place(x=420, y=135)

        hiding_elements = []

        lab9 = Label(app, text="Начальная степень", font=self.FONT)
        lab9.place(x=10, y=175)
        lab10 = Label(app, text="Конечная степень", font=self.FONT)
        lab10.place(x=10, y=200)
        hiding_elements.append(lab10)
        lab11 = Label(app, text="Шаг", font=self.FONT)
        lab11.place(x=10, y=225)
        hiding_elements.append(lab11)

        self.start_matrix_grade_input = Entry(app, width=10, validate="key", borderwidth=2)
        self.start_matrix_grade_input['validatecommand'] = (self.start_matrix_grade_input.register(self.test_val), '%P', '%d')
        self.start_matrix_grade_input.place(x=250, y=176)
        self.start_matrix_grade_input.insert(1, "1")
        self.end_matrix_grade_input = Entry(app, width=10, validate="key", borderwidth=2)
        self.end_matrix_grade_input['validatecommand'] = (self.end_matrix_grade_input.register(self.test_val), '%P', '%d')
        self.end_matrix_grade_input.place(x=250, y=200)
        self.end_matrix_grade_input.insert(1, "2")
        hiding_elements.append(self.end_matrix_grade_input)
        self.step_matrix_grade_input = Entry(app, width=10, validate="key", borderwidth=2)
        self.step_matrix_grade_input['validatecommand'] = (self.step_matrix_grade_input.register(self.test_val), '%P', '%d')
        self.step_matrix_grade_input.place(x=250, y=225)
        self.step_matrix_grade_input.insert(1, "1")
        hiding_elements.append(self.step_matrix_grade_input)

        self.creation_settings_var = BooleanVar()
        self.creation_settings_var.set(1)
        self.r1 = Radiobutton(text='Единичное постоение', font=self.FONT, variable=self.creation_settings_var, value=0)
        self.r1.bind('<Button-1>', lambda event: self.switch_hiding(hiding_elements))
        self.r1.place(x=10, y=150)
        self.r2 = Radiobutton(text='Цикличное построение', font=self.FONT, variable=self.creation_settings_var, value=1)
        self.r2.bind('<Button-1>', lambda event: self.switch_hiding(hiding_elements, False))
        self.r2.place(x=180, y=150)

        lab12 = Label(app, text="Знаков после запятой", font=self.FONT)
        lab12.place(x=540, y=15)
        self.decimal_places = Entry(app, width=10, validate="key", borderwidth=2)
        self.decimal_places['validatecommand'] = (self.decimal_places.register(self.test_val), '%P', '%d')
        self.decimal_places.place(x=720, y=15)
        self.decimal_places.insert(1, "4")

        self.text = Text(width=40, heigh=15, borderwidth=2)
        self.text.place(x=540, y=40)

        '''
        scroll = Scrollbar(text, command=text.yview)
        scroll.pack(side=RIGHT, fill=Y)
        text.config(yscrollcommand=scroll.set)
        '''
        # app.mainloop()

    def set_params(self, params):
        if len(params) < 3:
            self.text.insert(1.0, "ERRRRRor" + str(params))
        else:
            self.body_params = BodyParameters(int(params[0]), int(params[1]), int(params[2]))
            self.text.insert(1.0, "Параметры посторения " + str(params))

    def calculate_button_click(self):
        self.text.delete(1.0, END)
        c = Calculations(self)
        c.calculate(self.body_params)

    def switch_hiding(self, elements, hide=True):
        if hide:
            for i in elements:
                i.lower()
            self.creation_settings_var.set(False)
        else:
            for i in elements:
                i.tkraise()
            self.creation_settings_var.set(True)

    @staticmethod
    def test_val(in_str, acttyp):
        if acttyp == '1':  # insert
            if in_str.isdigit() or in_str == '.':
                return True
            else:
                return False
        return True

    @staticmethod
    def only_numeric_input(e):
        '''
        if e.isdigit() or e=="":
            return True
        else:
            return False
            '''
        return True if (e.isdigit() or e == "") else False
