import api from '../config/api';

const serviceService = {
  /**
   * Obtiene todos los servicios
   */
  getAll: async () => {
    try {
      const response = await api.get('/service');
      return response.data || [];
    } catch (error) {
      throw error;
    }
  },

  /**
   * Obtiene un servicio por ID
   */
  getById: async (id) => {
    try {
      const response = await api.get(`/service/${id}`);
      return response.data;
    } catch (error) {
      throw error;
    }
  },

  /**
   * Obtiene todos los servicios activos
   */
  getActive: async () => {
    try {
      const response = await api.get('/service/active');
      return response.data || [];
    } catch (error) {
      throw error;
    }
  },

  /**
   * Obtiene servicios de tipo suscripción
   */
  getSubscriptions: async () => {
    try {
      const response = await api.get('/service/subscriptions');
      return response.data || [];
    } catch (error) {
      throw error;
    }
  },

  /**
   * Crea un nuevo servicio
   */
  create: async (serviceData) => {
    try {
      const response = await api.post('/service', serviceData);
      return response.data;
    } catch (error) {
      throw error;
    }
  },

  /**
   * Actualiza un servicio existente
   */
  update: async (id, serviceData) => {
    try {
      const response = await api.put(`/service/${id}`, serviceData);
      return response;
    } catch (error) {
      throw error;
    }
  },

  /**
   * Elimina un servicio (borrado lógico)
   */
  delete: async (id) => {
    try {
      const response = await api.delete(`/service/${id}`);
      return response;
    } catch (error) {
      throw error;
    }
  }
};

export default serviceService;
