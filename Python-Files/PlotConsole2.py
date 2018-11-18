import matplotlib.pyplot as plt

fig = plt.figure(facecolor="#979899")
ax = plt.gca()
ax.set_facecolor("#d1d1d1")

plt.xticks([1,2,3,4,5],["11/13\nTue","11/14\nWed","11/15\nThu","11/16\nFri","11/17\nSat"])
plt.yticks([0.0,0.1,0.2,0.3,0.4,0.5],["0 %","0.1 %","0.2 %","0.3 %","0.4 %","0.5 %"])

x = [1,2,3,4,5]
y = [0.31,0.22,0.22,0.22,0.21]

for i,item in enumerate(y):
    xP = x[i]
    yP = y[i]
    # plt.text(xP-0.1,yP+0.01,str(item) + "%",fontsize=11)
    plt.text(xP-0.1,yP+0.01,str(item),fontsize=11)



plt.scatter(x,y)
plt.plot(x,y)

plt.show()