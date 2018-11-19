import matplotlib.pyplot as plt

daysX = [1,2,3,4,5]

styxY = [0.31,0.22,0.22,0.22,0.21]
stefY = [0.03,0.03,0.03,0.02,0.02]
cnnY = [0.11,0.12,0.10,0.09,0.09]


fig = plt.figure(facecolor="#979899")
ax = plt.gca()
ax.set_facecolor("#d1d1d1")

plt.grid(true)
plt.title("Styxhexenhammer666 vs Stefan Molyneux View Growth Rate- 2018\n",fontsize=16)
plt.xlabel("")
plt.ylabel("Groth Rate in %")


plt.xticks([1,2,3,4,5],["11/13\nTue","11/14\nWed","11/15\nThu","11/16\nFri","11/17\nSat"])
plt.yticks([0.0,0.1,0.2,0.3,0.4,0.5],["0 %","0.1 %","0.2 %","0.3 %","0.4 %","0.5 %"])



plt.scatter(daysX,styxY)
plt.plot(daysX,styxY,label="Styxhexenhammer666")

plt.scatter(daysX,stefY)
plt.plot(daysX,stefY,label="Stefan Molyneux")

plt.scatter(daysX,cnnY)
plt.plot(daysX,cnnY,label="Cnn")


for i,item in enumerate(styxY):
    x = daysX[i]
    y = styxY[i]
    plt.text(x-0.1,y+0.01,str(item) + "%",fontsize=11)

for i,item in enumerate(stefY):
    x = daysX[i]
    y = stefY[i]
    plt.text(x-0.1,y+0.01,str(item) + "%",fontsize=11)

for i,item in enumerate(cnnY):
    x = daysX[i]
    y = cnnY[i]
    plt.text(x-0.1,y+0.01,str(item) + "%",fontsize=11)

plt.legend()
plt.show()


# fig = plt.figure()
# ax1 = fig.add_subplot(111)
# ax2 = fig.add_subplot(111)
# plt.show()