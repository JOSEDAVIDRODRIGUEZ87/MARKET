// src/components/AuthGuard.js
import { Navigate } from 'react-router-dom';

export const AuthGuard = ({ children }) => {
    const token = localStorage.getItem('token');
    return token ? children : <Navigate to="/login" />;
};