import matplotlib.pyplot as plt

# arr1 = ["2018-Jan","2018-Feb","2018-Mar"]
# arr2 = ["0%","0.3%","0.22%"]

arr1 = [1,2,3]
arr2 = [0.0,0.3,0.22]

plt.scatter(arr1,arr2)
plt.plot(arr1,arr2)

plt.title("This is some title that I do thing looks very neat indeed")
plt.xlabel("This is something I wanna show")
plt.ylabel("Something else enterily")

plt.show()