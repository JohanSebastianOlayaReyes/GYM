import api from '../config/api';

const adminService = {
  /**
   * Registra un nuevo administrador
   */
  register: async (registerData) => {
    try {
      const response = await api.post('/admin/register', registerData);
      return response;
    } catch (error) {
      throw error;
    }
  },

  /**
   * Inicia sesión como administrador
   */
  login: async (loginData) => {
    try {
      const response = await api.post('/admin/login', loginData);

      // Guardar token y datos del admin en localStorage
      if (response.success && response.data) {
        localStorage.setItem('token', response.data.token);
        localStorage.setItem('admin', JSON.stringify(response.data));
      }

      return response;
    } catch (error) {
      throw error;
    }
  },

  /**
   * Verifica si un email ya está registrado
   */
  checkEmail: async (email) => {
    try {
      const response = await api.get(`/admin/check-email/${email}`);
      return response;
    } catch (error) {
      throw error;
    }
  },

  /**
   * Cierra la sesión del administrador
   */
  logout: () => {
    localStorage.removeItem('token');
    localStorage.removeItem('admin');
  },

  /**
   * Obtiene el administrador actual desde localStorage
   */
  getCurrentAdmin: () => {
    const adminData = localStorage.getItem('admin');
    return adminData ? JSON.parse(adminData) : null;
  },

  /**
   * Verifica si hay un administrador autenticado
   */
  isAuthenticated: () => {
    return !!localStorage.getItem('token');
  }
};

export default adminService;
