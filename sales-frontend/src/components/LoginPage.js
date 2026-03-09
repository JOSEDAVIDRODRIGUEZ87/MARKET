const handleLogin = async (data) => {
  const response = await api.post('/auth/login', data);
  localStorage.setItem('token', response.data.token);
  navigate('/products');
};