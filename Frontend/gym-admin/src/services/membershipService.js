import api from '../config/api';

const membershipService = {
  /**
   * Obtiene todas las membresías
   */
  getAll: async () => {
    try {
      const response = await api.get('/membership');
      return response.data || [];
    } catch (error) {
      throw error;
    }
  },

  /**
   * Obtiene una membresía por ID
   */
  getById: async (id) => {
    try {
      const response = await api.get(`/membership/${id}`);
      return response.data;
    } catch (error) {
      throw error;
    }
  },

  /**
   * Obtiene todas las membresías activas
   */
  getActive: async () => {
    try {
      const response = await api.get('/membership/active');
      return response.data || [];
    } catch (error) {
      throw error;
    }
  },

  /**
   * Obtiene todas las membresías expiradas
   */
  getExpired: async () => {
    try {
      const response = await api.get('/membership/expired');
      return response.data || [];
    } catch (error) {
      throw error;
    }
  },

  /**
   * Obtiene membresías por usuario
   */
  getByUserId: async (userId) => {
    try {
      const response = await api.get(`/membership/user/${userId}`);
      return response.data || [];
    } catch (error) {
      throw error;
    }
  },

  /**
   * Obtiene la membresía actual de un usuario
   */
  getCurrentByUserId: async (userId) => {
    try {
      const response = await api.get(`/membership/user/${userId}/current`);
      return response.data;
    } catch (error) {
      throw error;
    }
  },

  /**
   * Obtiene el conteo de membresías activas
   */
  getActiveCount: async () => {
    try {
      const response = await api.get('/membership/active/count');
      return response.data;
    } catch (error) {
      throw error;
    }
  },

  /**
   * Crea una nueva membresía
   */
  create: async (membershipData) => {
    try {
      const response = await api.post('/membership', membershipData);
      return response.data;
    } catch (error) {
      throw error;
    }
  },

  /**
   * Actualiza una membresía existente
   */
  update: async (id, membershipData) => {
    try {
      const response = await api.put(`/membership/${id}`, membershipData);
      return response;
    } catch (error) {
      throw error;
    }
  },

  /**
   * Extiende la duración de una membresía
   */
  extend: async (id, additionalDays) => {
    try {
      const response = await api.patch(`/membership/${id}/extend`, additionalDays);
      return response;
    } catch (error) {
      throw error;
    }
  },

  /**
   * Elimina una membresía (borrado lógico)
   */
  delete: async (id) => {
    try {
      const response = await api.delete(`/membership/${id}`);
      return response;
    } catch (error) {
      throw error;
    }
  }
};

export default membershipService;
