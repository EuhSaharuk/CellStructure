from abc import ABC, abstractmethod
from BodyParameters import *
from math import pi, tan, sin
from decimal import Decimal

class AbstractAngle(ABC):

    body = BodyParameters(0, 0, 0)
    accuracy = Decimal("7")
    columns = rows = Decimal('0')
    side =  Decimal('0')
    angle_num =  Decimal('0')
    cell_heigh =  Decimal('0')
    local =  Decimal('0')
    s_cells = s_cell =  Decimal('0')
    radius =  Decimal('0')
    availability = False
    v_cells =  Decimal('0')
    info = ""

    def __init__(self, body):
        self.body = body


    @abstractmethod
    def calculation(self):
        pass

    def try_size_condition(self):
        self.local = self.body.width / self.columns
        buf = self.body.length / self.rows
        return self.local == buf


class AbstractRelationAngle(AbstractAngle, ABC):

    k_x = k_y = Decimal('0')
    max_c = Decimal(str(pi / 4))
    relation = Decimal('0')

    def __init__(self, body):
        super().__init__(body)


class CircleCells(AbstractRelationAngle):

    def __init__(self, boby_params):
        super().__init__(boby_params)
        self.angle_num = 0

    def calculation(self):
        if not self.try_size_condition():
            return

        self.s_cells = self.v_cells / self.cell_heigh
        self.s_cell = self.s_cells / (self.rows * self.columns)

        self.radius = (self.s_cell/pi)**0.5
        self.relation = self.radius**2 * pi / self.local**2
        self.availability = self.relation < self.max_c
        self.k_x = (self.body.width - self.radius * 2 * self.rows)/(self.rows + 1)
        self.k_y = (self.body.length - self.radius * 2 * self.columns)/(self.columns + 1)


class TriangleCells(AbstractAngle):

    triangle_height =  Decimal('0')
    k_x = k_y = Decimal('0')

    def __init__(self, body_params):
        super().__init__(body_params)
        self.angle_num = 3

    def calculation(self):
        if not self.try_size_condition():
            return

        self.s_cells = self.v_cells / self.cell_heigh
        self.s_cell = self.s_cells / (self.rows * self.columns)
        self.side = (self.s_cell * 4 / 3**0.5)**0.5

        if self.side > self.local:
            self.availability = False
            return
        self.triangle_height = self.side * 3**0.5 / 2
        self.radius = self.side * 3**0.5 / 3

        self.k_x = (self.body.width - self.side * self.rows)/(self.rows + 1)
        self.k_y = (self.body.length - self.triangle_height * self.columns)/(self.columns + 1)

        if (self.side * self.rows + (self.rows + 1) * self.k_x <= self.body.width) and \
                (self.triangle_height * self.columns + (self.columns + 1) * self.k_y <= self.body.length):
            self.availability = True
        else:
            self.availability = False


class RectangleCells(AbstractAngle):

    k =  Decimal('0')
    v_cell_fact =  Decimal('0')
    cell_width = cell_length =  Decimal('0')

    def __init__(self, body_params):
        super().__init__(body_params)
        self.angle_num = 4

    def calculation(self):
        # self.info += "\n******** info ********"

        self.s_cells = self.v_cells / self.cell_heigh
        self.s_cell = self.s_cells / (self.rows * self.columns)

        a = (self.columns + 1) * (self.rows + 1)
        b = self.body.length * (self.rows + 1) + self.body.width * (self.columns + 1)
        b *= -1
        c = self.body.length * self.body.width - self.s_cell * self.columns * self.rows

        # self.info += "\n A =" + str(a) + " B =" + str(b) + " C = " + str(c) + "\n"
        self.availability = self.get_root(a, b, c) == 1

    def get_root(self, a, b, c):
        d = b**2 - 4 * a * c
        # self.info += "D  =" + str(d)
        if d < 0:
            return -1
        elif d == 0:
            self.k = -b / 2 / a
            self.cell_length = (self.body.length - self.k * (self.columns + 1)) / self.columns
            self.cell_width = (self.body.width - self.k * (self.rows + 1)) / self.rows

            if round((self.cell_length * self.cell_width), 2) == round(self.s_cell, 2):
                return 1
            else:
                return -1
        else:
            self.k = (-b + d**0.5) / (2 * a)
            # self.info += "\nk  =" + str(self.k)
            self.cell_length = abs(self.body.length - self.k * (self.columns + 1)) / self.columns
            self.cell_width = abs(self.body.width - self.k * (self.rows + 1)) / self.rows
            # self.info += " \nL = " + str(self.cell_length) + "\nW = " + str(self.cell_width) + " \nS = " + str(round((self.cell_length * self.cell_width), 2))
            # self.info += " \nWot Эto wot: " + str(round((self.cell_length * self.cell_width), 2) == round(self.s_cell, 2))
            if self.cell_length > 0 and self.cell_width > 0 and \
                    round((self.cell_length * self.cell_width), 2) == round(self.s_cell, 2):
                return 1
            self.k = (-b - d ** 0.5) / 2 * a
            # self.info += "\nk  =" + str(self.k)
            self.cell_length = abs(self.body.length - self.k * (self.columns + 1)) / self.columns
            self.cell_width = abs(self.body.width - self.k * (self.rows + 1)) / self.rows
            # self.info += " L = " + str(self.cell_length) + "\nW = " + str(self.cell_width) + " \nS = " + str(
            #    round((self.cell_length * self.cell_width), 2))
            if self.cell_length > 0 and self.cell_width > 0 and \
                    round((self.cell_length * self.cell_width), 2) == round(self.s_cell, 2):
                return 1
            return -1


class NAngleCells(AbstractRelationAngle):

    def __init__(self, body_params):
        super().__init__(body_params)

    def calculation(self):
        if not self.try_size_condition():
            return

        self.s_cells = self.v_cells / self.cell_heigh
        self.s_cell = self.s_cells / (self.rows * self.columns)

        rad = (180 / self.angle_num) * pi / 180
        self.side = (4 * self.s_cell / (self.angle_num * (1 / tan(rad))))**0.5

        rad = 180 / self.angle_num * pi / 180
        self.radius = self.side / (2 * sin(rad))

        self.k_x = (self.body.width - (2 * self.radius * self.rows)) / (self.rows + 1)
        self.k_y = (self.body.length - (2 * self.radius * self.columns)) / (self.columns + 1)

        self.relation = self.radius**2 * pi / self.local**2
        self.availability = self.relation < self.max_c
