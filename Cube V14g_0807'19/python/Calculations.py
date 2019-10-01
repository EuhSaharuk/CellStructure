from Cells import *
from BodyParameters import *
from tkinter import  END

class Calculations:

    def __init__(self, window):
        self.window = window
        self.body_params = BodyParameters(0, 0, 0)
        self.start = Decimal('0')
        self.end = Decimal('0')
        self.step = Decimal('0')
        self.cells = AbstractAngle

    def calculate(self, body_params):
        self.body_params = body_params

        if int(self.window.cell_high_input.get()) > self.body_params.height:
            self.window.text.insert(1.0, "Высота ячёки не может быть больше высоты тела")
            return

        if self.window.creation_settings_var.get():
            self.start = min(int(self.window.start_matrix_grade_input.get()), int(self.window.end_matrix_grade_input.get()))
            self.end = max(int(self.window.start_matrix_grade_input.get()), int(self.window.end_matrix_grade_input.get()))
            self.step = abs(int(self.window.step_matrix_grade_input.get()))
        else:
            self.start = self.end = int(self.window.start_matrix_grade_input.get())
            self.step = 1
        if self.step == 0:
            self.loop_angle_num(self.start)
        else:
            i = self.start
            while i <= self.end:

                self.loop_angle_num(i)
                i += 1

    def loop_angle_num(self, matrix_grade):
        angle_start = min(int(self.window.number_of_angles_start_input.get()), int(self.window.number_of_angles_end_input.get()))
        angle_end = max(int(self.window.number_of_angles_start_input.get()), int(self.window.number_of_angles_end_input.get()))
        angle_step = abs(int(self.window.number_of_angles_step_input.get()))
        '''
        if angle_end > angle_start:
            angel_step = abs(angle_step)
        else:
            angel_step = abs(angle_step) * -1
        '''
        if angle_step == 0:
            angle_end = angle_start
            angle_step = 1
            '''
            if angle_start == 2:
                self.cells = CircleCells(self.body_params)
                self.cells.columns = self.cells.rows = matrix_grade
            elif angle_start == 3:
                self.cells = TriangleCells(self.body_params)
                self.cells.columns = self.cells.rows = matrix_grade
            elif angle_start == 4:
                self.cells = RectangleCells(self.body_params)
                self.cells.columns = self.cells.rows = matrix_grade
            else:
                self.cells = NAngleCells(self.body_params)
                self.cells.columns = self.cells.rows = matrix_grade
                self.cells.angle_num(angle_start)
            self.loop_volume(angle_start)
            return'''

        i = angle_start
        while i <= angle_end:
            if i == 2:
                self.cells = CircleCells(self.body_params)
                self.cells.columns = self.cells.rows = matrix_grade
            elif i == 3:
                self.cells = TriangleCells(self.body_params)
                self.cells.columns = self.cells.rows = matrix_grade
            elif i == 4:
                self.cells = RectangleCells(self.body_params)
                self.cells.columns = self.cells.rows = matrix_grade
            else:
                self.cells = NAngleCells(self.body_params)
                self.cells.columns = self.cells.rows = matrix_grade
                self.cells.angle_num = i
            self.loop_volume(i)
            '''
            if i == angle_end:
                break'''
            i += angle_step

    def loop_volume(self, angle):
        volume_start = float(self.window.part_of_volume_start_input.get())
        volume_end = float(self.window.part_of_volume_end_input.get())
        volume_step = float(self.window.part_of_volume_step_input.get())

        if volume_end >= volume_start:
            volume_step = abs(volume_step)
        else:
            volume_step = abs(volume_step) * -1

        if volume_step > 0:
            i = volume_start
            while i <= volume_end:
                self.cells.v_cells = self.body_params.v * i / 100
                self.calculation(angle)
                i += volume_step

        elif volume_step < 0:
            i = volume_start
            while i >= volume_end:
                self.cells.v_cells = self.body_params.v * i / 100
                self.calculation(angle)
                i += volume_step

        else:
            self.cells.v_cells = self.body_params.v * volume_start / 100
            self.calculation(angle)

    def calculation(self, angle):
        self.cells.cell_heigh = int(self.window.cell_high_input.get())
        self.cells.accuracy = int(self.window.decimal_places.get())
        self.cells.calculation()
        if angle == 4:
            self.window.text.insert(END, self.result_to_str())
        else:
            self.window.text.insert(END, self.result_to_str())

    def result_to_str(self):
        ac = int(self.window.decimal_places.get())
        result = ""
        result += "Степень матрицы - " + str(self.cells.columns) + "\n"
        result += "Количество углов - " + str(self.cells.angle_num) + "\n"
        result += "Обьём тела - " + str(round(self.cells.body.v, ac)) + "\n"
        result += "Обьём структуры - " + str(round(self.cells.v_cells, ac)) + "\n"
        result += "Часть от объёма - " + str(round(self.cells.v_cells * 100 / self.body_params.v, ac)) + "\n"
        result += "Площадь структуры - " + str(round(self.cells.s_cells, ac)) + "\n"
        result += "Площадь 1 ячейки - " + str(round(self.cells.s_cell, ac)) + "\n"

        if isinstance(self.cells, AbstractRelationAngle):
            result += "Локаль - " + str(round(self.cells.local, ac)) + "\n"
            result += "Радиус вписаной в локаль окружности - " + str(round(self.cells.radius, ac)) + "\n"
            result += "Сторона вписанного в окружность многоулольника - " + str(round(self.cells.side, ac)) + "\n"
            result += "K_x = " + str(round(self.cells.k_y, ac)) + "\n"
            result += "K_y = " + str(round(self.cells.k_x, ac)) + "\n"
            result += "Коэффицент соотношения площадей - " + str(round(self.cells.relation, ac)) + "\n"
            result += "Максимальное соотношение - " + str(round(self.cells.max_c, ac)) + "\n"
        if isinstance(self.cells, TriangleCells):
            result += "Локаль - " + str(round(self.cells.local, ac)) + "\n"
            result += "Радиус вписаной в локаль окружности - " + str(round(self.cells.radius, ac)) + "\n"
            result += "Сторона вписанного в окружность Треугольника - " + str(round(self.cells.side, ac)) + "\n"
            result += "K_x = " + str(round(self.cells.k_x, ac)) + "\n"
            result += "K_y = " + str(round(self.cells.k_y, ac)) + "\n"
        if isinstance(self.cells, RectangleCells):
            result += "Ширина 1 ячейки - " + str(round(self.cells.cell_width, ac)) + "\n"
            result += "Длинна 1 ячейки - " + str(round(self.cells.cell_length, ac)) + "\n"
            result += "K = " + str(round(self.cells.k, ac)) + "\n"
            # result += self.cells.info

        result += "Доступность построения - " + str(self.cells.availability) + "\n\n\n"
        return result



