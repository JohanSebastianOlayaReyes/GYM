import api from '../config/api';

const userService = {
  /**
   * Obtiene todos los usuarios
   */
  getAll: async () => {
    try {
      const response = await api.get('/user');
      return response.data || [];
    } catch (error) {
      throw error;
    }
  },

  /**
   * Obtiene un usuario por ID
   */
  getById: async (id) => {
    try {
      const response = await api.get(`/user/${id}`);
      return response.data;
    } catch (error) {
      throw error;
    }
  },

  /**
   * Obtiene un usuario por email
   */
  getByEmail: async (email) => {
    try {
      const response = await api.get(`/user/email/${email}`);
      return response.data;
    } catch (error) {
      throw error;
    }
  },

  /**
   * Crea un nuevo usuario
   */
  create: async (userData) => {
    try {
      const response = await api.post('/user', userData);
      return response.data;
    } catch (error) {
      throw error;
    }
  },

  /**
   * Actualiza un usuario existente
   */
  update: async (id, userData) => {
    try {
      const response = await api.put(`/user/${id}`, userData);
      return response;
    } catch (error) {
      throw error;
    }
  },

  /**
   * Elimina un usuario (borrado lógico)
   */
  delete: async (id) => {
    try {
      const response = await api.delete(`/user/${id}`);
      return response;
    } catch (error) {
      throw error;
    }
  }
};

export default userService;
