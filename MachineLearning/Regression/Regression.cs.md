# Linear Regression
 *Linear Regression is used to predict the value of a variable (the dependent variable) using another variable (the independent variable)*  
--- -


Definitions:
* **Dependent Variable** 
: The variable that is being predicted
* **Independent Variable**
: The variable used to predicct the Dependent Variable
* **The Interceptor**
: What value the dependent variable holds when the independent variable(s) are 0
* **Estimated**
: The value of the dependent variable using Linear Regression
* **Actual**
: The value of the dependent in the dataset
* **$R^2$**
: How well our regression line can predict values


## The formula for Linear Regression
$\hat{y} =  B_{0}  + B_{1}x $

* $B_{0}$ = The interceptor or bias of the dependent variable
* $B_{1}$ = The gradient or weight of the independent variable
* $x$ = The Independent Variable
* $\hat{y}$ = The variable we wish to predict (The dependent variable)

When $B_{1}$ is a positive non-zero number we speak of a positive relation\
When $B_{1}$ is a negative non-zero number we speak of a negative relation\
--- -
## Calculating the linear regression line using Least Square Method
*For this example we shall use a few made up values to calculate the regression line*

|$B_{0}$ |$B_{1}$   
|:---:   |:---:|
| 1      | 30  |
| 2      | 25  |
| 3      | 38  |
| 4      | 52  |
| 5      | 67  |

- Now we wish to take the mean of the values of both columns\
    for $B_{0}$ this is $3$\
    for $B_{1}$ this is $42.4$
- We will now take the $\Delta$ from each actual value to the mean value

|$B_{0}$ |$B_{1}$   |$B_{0} - \tilde{B_{0}}$ |$B_{1} - \tilde{B_{1}}$   
|:---:   |:---:|:---: |:---:|
| 1      | 30  |-2 |-12.4 |
| 2      | 25  |-1 |-17.4 |
| 3      | 38  |0  |-4.4  |
| 4      | 52  |1  |9.6   |
| 5      | 67  |2  |24.6  |

In order to check the correctness of our derived values (3rd and 4th columns) we double check that the sum of that column equals 0.\
$-2 + -1 + 0 +1 + 2 = 0$ So this column is correct\
$-12.4 + -17.4 + -4.4 + 9.6 + 24.6 = 0$ So this column is correct as well.

-  Now we need to square up the $B_{0}{\Delta}$ and multiply the values of the 3rd and 4th column together from giving us the following values:

|$B_{0}$ |$B_{1}$   |$B_{0} - \tilde{B_{0}}$ |$B_{1} - \tilde{B_{1}}$   | ($B_{0} - \tilde{B_{0}})^2$ |$(B_{0} - \tilde{B_{0}}) (B_{1} - \tilde{B_{1}})$ |
|:---:   |:---:|:---: |:---:| :---:| :---:|
| 1      | 30  |-2 |-12.4 |4 |24.8 |
| 2      | 25  |-1 |-17.4 |1 |17.4 |
| 3      | 38  |0  |-4.4  |0 |0    |
| 4      | 52  |1  |9.6   |1 |9.6  |
| 5      | 67  |2  |24.6  |4 |49.2 |

- With these new columns we will add them sum them up (seperatly) and divide them with eachother to give the value of $B_{1}$  in the regression line
- Column 4 adds up to 10 and Column 5 adds up to 101
- Now we divide 101 by 10 so we get $\frac{101}{10} = 10.1 = \frac{\sum(B_{0} - \tilde{B_{0}}) (B_{1} - \tilde{B_{1}})}{\sum(B_{0} - \tilde{B_{0}})^2}$
- Now we know that $B_{1} = 10.1$

That changes the formula from:\
$\hat{y} =  B_{0}  + B_{1}x $\
To:\
$\hat{y} =  B_{0}  + 10.1x $
- With this knowledge all we need to calculate $B_{0}$ is the value of $\hat{y}$ which we get by filling in the formula using our mean data. the regression **WILL ALWAYS** pass through the mean data point!
- Lets take $x = 3$ for this example we also know that for $x = 3, \hat{y} = 42.4$, our formula now becomes:

$42.4 =  B_{0}  + 10.1*3 $\
$42.4 =  B_{0}  + 30.3 $\
$12.1 =  B_{0} $\
$B_{0} = 12.1 $

- With $B_{0}$ being 12.1 we now know our intercept and all the unknowns in our formula. Which means we can start predicting!

The formula ended up as:\
$\hat{y} =  12.1  + 10.1x $
--- -
## Checking Performance
- $R^2$ is determined by the distance of each predicted vale compared to the mean.\
In the previous bit we already used some values lets use those again! and remember:\
$\hat{y} =  12.1  + 10.1x $\
$\tilde{y} = 42.4$

|$x$ |$y$    |$y - \tilde{y}$   | ($y - \tilde{y})^2$ |
|:---:   |:---:|:---:| :---:|
| 1      | 30  | -12.4  | 153.76 |
| 2      | 25  | -17.4  | 302.76 |
| 3      | 38  | -4.4   | 19.36  |    
| 4      | 52  | 9.6    | 92.16  |
| 5      | 67  | 24.6   | 605.16 |

Yet again we can check the validity of our data by summing the $y - \hat{y}$ column\
$\sum{y - \hat{y}} = 0$\
In this case we are correct as $-12.4 + -17.4 + -4.4 + 9.6 + 24.6 = 0$\
We also need to grab the sum of the last column so:\
$\sum{(y - \tilde{y})^2} = 153.76 + 302.76 + 19.36 + 92.16 +605.16 = 1,173.2$ 

Lets now do the exact same but for the predicted values

|$x$ |$\hat{y}$    |$\hat{y} - \tilde{y}$   | ($\hat{y} - \tilde{y})^2$ |
|:---:   |:---:|:---:| :---:|
| 1      | 22.2  | -20.2 | 408.04 |
| 2      | 32.3  | -10.1 | 102.01 |
| 3      | 42.4  | 0     | 0      |    
| 4      | 52.5  | 10.1  | 102.01 |
| 5      | 62.6  | 20.2  | 408.04 |

Yet again the sum of the $\hat{y} - \tilde{y} = 0$
Lets grab the sum of the last column as well:\
$\sum{(\hat{y} - \tilde{y})^2} = 408.04 + 102.01 + 0 + 102.01 + 408.04 = 1,020.1$

Now $R^2 = \frac{\sum{(\hat{y} - \tilde{y})^2}}{\sum{(y - \tilde{y})^2}} = \frac{1020.1}{1173.2} \approx 0.86950...$ \
Which means the regression we made is about 87% fit\
And well 87%? that isnt good. Most statistical analyses require 95% or even 99% accuracy!\
The higher the number the better!