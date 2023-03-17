#!/usr/bin/env python
# coding: utf-8

# In[79]:


import numpy as np
import pandas as pd
size = 300
X = np.random.rand(size)*5-2.5
w4, w3, w2, w1, w0 = 1, 2, 1, -4, 2
y = w4*(X**4) + w3*(X**3) + w2*(X**2) + w1*X + w0 + np.random.randn(size)*8-4
df = pd.DataFrame({'x': X, 'y': y})
df.to_csv('dane_do_regresji.csv',index=None)
df.plot.scatter(x='x',y='y')

output_df = pd.DataFrame(columns=['train_mse','test_mse'])
output_list = []


# In[80]:


from sklearn.model_selection import train_test_split
X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.2, random_state=42)
X_train.shape, X_test.shape
# y_train.shape , y_test.shape


# 

# In[81]:


from sklearn.linear_model import LinearRegression
lin_reg = LinearRegression()
lin_reg.fit(X_train.reshape(-1,1), y_train)
from sklearn.metrics import mean_squared_error

y_pred1 = lin_reg.predict(X_train.reshape(-1,1))
mean_squared_error(y_train, y_pred1)

y_pred = lin_reg.predict(X_test.reshape(-1,1))
mean_squared_error(y_test, y_pred)

df_lin_reg = pd.DataFrame({'train_mse': [mean_squared_error(y_train, y_pred1)],
                        'test_mse': [mean_squared_error(y_test, y_pred)]},
                        index=['lin_reg'])
# output_df = output_df.append(df_lin_reg)
output_list.append((lin_reg, None))
output_df = pd.concat([output_df, df_lin_reg])
output_df


# 

# In[82]:


import sklearn.neighbors
knn_reg = sklearn.neighbors.KNeighborsRegressor(n_neighbors=3)
knn_reg.fit(X_train.reshape(-1,1), y_train)

y_pred1 = knn_reg.predict(X_train.reshape(-1,1))
y_pred = knn_reg.predict(X_test.reshape(-1,1))
mean_squared_error(y_test, y_pred)


df_knn_3_reg = pd.DataFrame({'train_mse': [mean_squared_error(y_train, y_pred1)],
                        'test_mse': [mean_squared_error(y_test, y_pred)]},
                        index=['knn_3_reg'])
output_list.append((knn_reg, None))
output_df = pd.concat([output_df, df_knn_3_reg])


# In[83]:


knn_reg = sklearn.neighbors.KNeighborsRegressor(n_neighbors=5)
knn_reg.fit(X_train.reshape(-1,1), y_train)

y_pred1 = knn_reg.predict(X_train.reshape(-1,1))
y_pred = knn_reg.predict(X_test.reshape(-1,1))
mean_squared_error(y_test, y_pred)

df_knn_5_reg = pd.DataFrame({'train_mse': [mean_squared_error(y_train, y_pred1)],
                        'test_mse': [mean_squared_error(y_test, y_pred)]},
                        index=['knn_5_reg'])
output_list.append((knn_reg, None))
output_df = pd.concat([output_df, df_knn_5_reg])


# In[84]:


from sklearn.preprocessing import PolynomialFeatures
poly_features = PolynomialFeatures(degree=2, include_bias=False)
X_train_poly = poly_features.fit_transform(X_train.reshape(-1,1))
X_test_poly = poly_features.fit_transform(X_test.reshape(-1,1))

lin_reg = LinearRegression()
lin_reg.fit(X_train_poly, y_train)

y_pred1 = lin_reg.predict(X_train_poly)
mean_squared_error(y_train, y_pred1)

y_pred = lin_reg.predict(X_test_poly)
mean_squared_error(y_test, y_pred)


df_poly_2_reg = pd.DataFrame({'train_mse': [mean_squared_error(y_train, y_pred1)],
                        'test_mse': [mean_squared_error(y_test, y_pred)]},
                        index=['poly_2_reg'])
output_list.append((lin_reg, poly_features))
output_df = pd.concat([output_df, df_poly_2_reg])


# In[85]:


poly_features = PolynomialFeatures(degree=3, include_bias=False)
X_train_poly = poly_features.fit_transform(X_train.reshape(-1,1))
X_test_poly = poly_features.fit_transform(X_test.reshape(-1,1))

lin_reg = LinearRegression()
lin_reg.fit(X_train_poly, y_train)

y_pred1 = lin_reg.predict(X_train_poly)
mean_squared_error(y_train, y_pred1)

y_pred = lin_reg.predict(X_test_poly)
mean_squared_error(y_test, y_pred)


df_poly_3_reg = pd.DataFrame({'train_mse': [mean_squared_error(y_train, y_pred1)],
                        'test_mse': [mean_squared_error(y_test, y_pred)]},
                        index=['poly_3_reg'])
output_list.append((lin_reg, poly_features))
output_df = pd.concat([output_df, df_poly_3_reg])


# In[86]:


poly_features = PolynomialFeatures(degree=4, include_bias=False)
X_train_poly = poly_features.fit_transform(X_train.reshape(-1,1))
X_test_poly = poly_features.fit_transform(X_test.reshape(-1,1))

lin_reg = LinearRegression()
lin_reg.fit(X_train_poly, y_train)

y_pred1 = lin_reg.predict(X_train_poly)
mean_squared_error(y_train, y_pred1)

y_pred = lin_reg.predict(X_test_poly)
mean_squared_error(y_test, y_pred)


df_poly_4_reg = pd.DataFrame({'train_mse': [mean_squared_error(y_train, y_pred1)],
                        'test_mse': [mean_squared_error(y_test, y_pred)]},
                        index=['poly_4_reg'])
output_list.append((lin_reg, poly_features))
output_df = pd.concat([output_df, df_poly_4_reg])


# In[87]:


poly_features = PolynomialFeatures(degree=5, include_bias=False)
X_train_poly = poly_features.fit_transform(X_train.reshape(-1,1))
X_test_poly = poly_features.fit_transform(X_test.reshape(-1,1))

lin_reg = LinearRegression()
lin_reg.fit(X_train_poly, y_train)

y_pred1 = lin_reg.predict(X_train_poly)
mean_squared_error(y_train, y_pred1)

y_pred = lin_reg.predict(X_test_poly)
mean_squared_error(y_test, y_pred)


df_poly_5_reg = pd.DataFrame({'train_mse': [mean_squared_error(y_train, y_pred1)],
                        'test_mse': [mean_squared_error(y_test, y_pred)]},
                        index=['poly_5_reg'])
output_list.append((lin_reg, poly_features))
output_df = pd.concat([output_df, df_poly_5_reg])


# In[88]:


output_df.to_pickle('mse.pkl')
output_df


# In[89]:


import pickle


with open('reg.pkl', 'wb') as f:
    pickle.dump(output_list, f)
output_list


# In[89]:




