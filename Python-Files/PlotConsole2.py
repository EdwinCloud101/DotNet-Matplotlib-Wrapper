import matplotlib.pyplot as plt

fig = plt.figure(facecolor="#979899")
ax = plt.gca()
ax.set_facecolor("#d1d1d1")

x = [1,2,3,4,5]
y = [0.31,0.22,0.22,0.22,0.21]

plt.plot(x,y)

plt.show()