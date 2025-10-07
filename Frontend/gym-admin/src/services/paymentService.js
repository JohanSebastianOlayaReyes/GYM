import api from '../config/api';

const paymentService = {
  /**
   * Obtiene todos los pagos
   */
  getAll: async () => {
    try {
      const response = await api.get('/payment');
      return response.data || [];
    } catch (error) {
      throw error;
    }
  },

  /**
   * Obtiene un pago por ID
   */
  getById: async (id) => {
    try {
      const response = await api.get(`/payment/${id}`);
      return response.data;
    } catch (error) {
      throw error;
    }
  },

  /**
   * Obtiene pagos por usuario
   */
  getByUserId: async (userId) => {
    try {
      const response = await api.get(`/payment/user/${userId}`);
      return response.data || [];
    } catch (error) {
      throw error;
    }
  },

  /**
   * Obtiene pagos por membresía
   */
  getByMembershipId: async (membershipId) => {
    try {
      const response = await api.get(`/payment/membership/${membershipId}`);
      return response.data || [];
    } catch (error) {
      throw error;
    }
  },

  /**
   * Obtiene pagos por rango de fechas
   */
  getByDateRange: async (startDate, endDate) => {
    try {
      const response = await api.get(`/payment/range?startDate=${startDate}&endDate=${endDate}`);
      return response.data || [];
    } catch (error) {
      throw error;
    }
  },

  /**
   * Obtiene los pagos más recientes
   */
  getRecent: async (count = 10) => {
    try {
      const response = await api.get(`/payment/recent/${count}`);
      return response.data || [];
    } catch (error) {
      throw error;
    }
  },

  /**
   * Obtiene el ingreso total de un mes
   */
  getMonthlyIncome: async (month, year) => {
    try {
      const response = await api.get(`/payment/income/month?month=${month}&year=${year}`);
      return response.data;
    } catch (error) {
      throw error;
    }
  },

  /**
   * Obtiene estadísticas de pagos por método
   */
  getStatsByMethod: async (month, year) => {
    try {
      const response = await api.get(`/payment/stats/method?month=${month}&year=${year}`);
      return response.data;
    } catch (error) {
      throw error;
    }
  },

  /**
   * Crea un nuevo pago
   */
  create: async (paymentData) => {
    try {
      const response = await api.post('/payment', paymentData);
      return response.data;
    } catch (error) {
      throw error;
    }
  },

  /**
   * Actualiza un pago existente
   */
  update: async (id, paymentData) => {
    try {
      const response = await api.put(`/payment/${id}`, paymentData);
      return response;
    } catch (error) {
      throw error;
    }
  },

  /**
   * Elimina un pago (borrado lógico)
   */
  delete: async (id) => {
    try {
      const response = await api.delete(`/payment/${id}`);
      return response;
    } catch (error) {
      throw error;
    }
  }
};

export default paymentService;
