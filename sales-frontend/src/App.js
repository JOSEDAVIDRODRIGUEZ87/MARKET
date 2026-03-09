import React from 'react';
import { BrowserRouter, Routes, Route, Navigate } from 'react-router-dom';
import './App.css';

// Importa tus componentes (debes crearlos)
import { AuthGuard } from './components/AuthGuard';
import { LoginPage } from './pages/LoginPage';
import { ProductList } from './pages/ProductList';
import { ProductForm } from './components/ProductForm';

function App() {
  return (
    <BrowserRouter>
      <div className="App">
        <Routes>
          {/* Ruta pública */}
          <Route path="/login" element={<LoginPage />} />

          {/* Rutas protegidas */}
          <Route path="/products" element={
            <AuthGuard>
              <ProductList />
            </AuthGuard>
          } />

          <Route path="/products/edit/:id" element={
            <AuthGuard>
              <ProductForm />
            </AuthGuard>
          } />

          {/* Ruta por defecto */}
          <Route path="/" element={<Navigate to="/products" />} />
        </Routes>
      </div>
    </BrowserRouter>
  );
}

export default App;