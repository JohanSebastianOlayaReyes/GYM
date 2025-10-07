import axios from 'axios';

// Base URL del backend API
export const API_BASE_URL = 'http://localhost:5000/api';

// Crear instancia de axios con configuración base
const api = axios.create({
  baseURL: API_BASE_URL,
  headers: {
    'Content-Type': 'application/json',
  },
  timeout: 10000, // 10 segundos
});

// Interceptor para agregar el token JWT a todas las peticiones
api.interceptors.request.use(
  (config) => {
    const token = localStorage.getItem('token');
    if (token) {
      config.headers.Authorization = `Bearer ${token}`;
    }
    return config;
  },
  (error) => {
    return Promise.reject(error);
  }
);

// Interceptor para manejar respuestas
api.interceptors.response.use(
  (response) => {
    // Si la respuesta viene envuelta en { success, data, message }
    if (response.data && response.data.success !== undefined) {
      return response.data;
    }
    return response;
  },
  (error) => {
    // Manejar errores globalmente
    if (error.response) {
      // El servidor respondió con un código de error
      const errorMessage = error.response.data?.message || 'Error en la petición';

      // Si es 401, redirigir al login
      if (error.response.status === 401) {
        localStorage.removeItem('token');
        localStorage.removeItem('admin');
        window.location.href = '/login';
      }

      return Promise.reject(new Error(errorMessage));
    } else if (error.request) {
      // La petición se hizo pero no hubo respuesta
      return Promise.reject(new Error('No se pudo conectar con el servidor'));
    } else {
      // Algo pasó al configurar la petición
      return Promise.reject(error);
    }
  }
);

export default api;
