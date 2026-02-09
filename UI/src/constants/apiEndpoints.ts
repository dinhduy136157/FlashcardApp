export const API_ENDPOINTS = {
  AUTH: {
    LOGIN: '/Auth/login',
    REGISTER: '/Auth/register',
  },
  GROUPS: {
    GET_ALL: '/Groups',
    GET_BY_ID: (id: string) => `/Groups/${id}`,
    CREATE: '/Groups',
  },
  FLASHCARDS: {
    GET_BY_GROUP: (groupId: string) => `/Flashcards/group/${groupId}`,
    CREATE: '/Flashcards',
    UPDATE: (id: string) => `/Flashcards/${id}`,
    DELETE: (id: string) => `/Flashcards/${id}`,
  }
} as const;