class BodyParameters:

    length = 0
    width = 0
    height = 0
    v = 0

    def __init__(self, width, length, height):
        self.width = width
        self.height = height
        self.length = length
        self.v = width * height * length
'''
    def __init__(self):
        pass
'''



'''
    def __init__(self, params):
        self.width = int(params[0])
        self.height = int(params[1])
        self.length = int(params[2])
        self.v = self.width * self.height * self.length
'''