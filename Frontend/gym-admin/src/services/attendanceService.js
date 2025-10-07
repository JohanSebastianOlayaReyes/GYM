import api from '../config/api';

const attendanceService = {
  /**
   * Obtiene todas las asistencias
   */
  getAll: async () => {
    try {
      const response = await api.get('/attendance');
      return response.data || [];
    } catch (error) {
      throw error;
    }
  },

  /**
   * Obtiene una asistencia por ID
   */
  getById: async (id) => {
    try {
      const response = await api.get(`/attendance/${id}`);
      return response.data;
    } catch (error) {
      throw error;
    }
  },

  /**
   * Obtiene asistencias por usuario
   */
  getByUserId: async (userId) => {
    try {
      const response = await api.get(`/attendance/user/${userId}`);
      return response.data || [];
    } catch (error) {
      throw error;
    }
  },

  /**
   * Obtiene asistencias de una fecha específica
   */
  getByDate: async (date) => {
    try {
      const response = await api.get(`/attendance/date?date=${date}`);
      return response.data || [];
    } catch (error) {
      throw error;
    }
  },

  /**
   * Obtiene las asistencias del día de hoy
   */
  getToday: async () => {
    try {
      const response = await api.get('/attendance/today');
      return response.data || [];
    } catch (error) {
      throw error;
    }
  },

  /**
   * Obtiene el conteo de asistencias del día
   */
  getTodayCount: async () => {
    try {
      const response = await api.get('/attendance/today/count');
      return response.data;
    } catch (error) {
      throw error;
    }
  },

  /**
   * Verifica si un usuario ya registró asistencia hoy
   */
  hasAttendedToday: async (userId) => {
    try {
      const response = await api.get(`/attendance/user/${userId}/has-attended-today`);
      return response.data;
    } catch (error) {
      throw error;
    }
  },

  /**
   * Obtiene asistencias por rango de fechas
   */
  getByDateRange: async (startDate, endDate) => {
    try {
      const response = await api.get(`/attendance/range?startDate=${startDate}&endDate=${endDate}`);
      return response.data || [];
    } catch (error) {
      throw error;
    }
  },

  /**
   * Obtiene el conteo de asistencias de un usuario en un rango de fechas
   */
  getCountByUser: async (userId, startDate, endDate) => {
    try {
      const response = await api.get(`/attendance/user/${userId}/count?startDate=${startDate}&endDate=${endDate}`);
      return response.data;
    } catch (error) {
      throw error;
    }
  },

  /**
   * Registra asistencia para un usuario (simplificado para el día actual)
   */
  register: async (userId, registrationMethod = 'Manual') => {
    try {
      const response = await api.post(`/attendance/register/${userId}?registrationMethod=${registrationMethod}`);
      return response;
    } catch (error) {
      throw error;
    }
  },

  /**
   * Crea una nueva asistencia manualmente (con todos los datos)
   */
  create: async (attendanceData) => {
    try {
      const response = await api.post('/attendance', attendanceData);
      return response.data;
    } catch (error) {
      throw error;
    }
  },

  /**
   * Actualiza una asistencia existente
   */
  update: async (id, attendanceData) => {
    try {
      const response = await api.put(`/attendance/${id}`, attendanceData);
      return response;
    } catch (error) {
      throw error;
    }
  },

  /**
   * Elimina una asistencia (borrado lógico)
   */
  delete: async (id) => {
    try {
      const response = await api.delete(`/attendance/${id}`);
      return response;
    } catch (error) {
      throw error;
    }
  }
};

export default attendanceService;
