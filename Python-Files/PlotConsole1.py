import matplotlib.pyplot as plt


styxX = [1,2,3,4,5]
styxY = [0.31,0.22,0.22,0.22,0.21]

stefX = [1,2,3,4,5]
stefY = [0.03,0.03,0.03,0.02,0.02]

plt.grid(False)
plt.title("Styxhexenhammer666 vs Stefan Molyneux View Growth Rate- 2018")
plt.xlabel("")
plt.ylabel("Groth Rate in %")


plt.xticks([1,2,3,4,5],["11/13\nTue","11/14\nWed","11/15\nThu","11/16\nFri","11/17\nSat"])
plt.yticks([0.0,0.1,0.2,0.3,0.4,0.5],["0 %","0.1 %","0.2 %","0.3 %","0.4 %","0.5 %"])

plt.scatter(styxX,styxY)
plt.plot(styxX,styxY,label="Styxhexenhammer666")

plt.scatter(stefX,stefY)
plt.plot(stefX,stefY,label="Stefan Molyneux")

for i,item in enumerate(styxY):
    x = styxX[i]
    y = styxY[i]
    plt.text(x-0.1,y+0.01,str(item) + "%",fontsize=11)

for i,item in enumerate(stefY):
    x = stefX[i]
    y = stefY[i]
    plt.text(x-0.1,y+0.01,str(item) + "%",fontsize=11)

plt.legend()
plt.show()


# fig = plt.figure()
# ax1 = fig.add_subplot(111)
# ax2 = fig.add_subplot(111)
# plt.show()