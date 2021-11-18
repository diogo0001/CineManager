import { APP_URL } from "../globals";
import axios from "axios";

const URL = {
  LOGIN: "/login/",
  ROOMS: "/rooms/",
  MOVIES: "/movies/",
  SESSIONS: "/sessions/",
};

export const axiosInstance = axios.create({
  baseURL: APP_URL,
});

// Movies
export const getMovies = () => {
  return axiosInstance.get(`${URL.MOVIES}`, {});
};

export const getMovie = (id) => {
  return axiosInstance.get(`${URL.MOVIES}${id}`, {});
};

export const updateMovie = (id, model) => {
  return axiosInstance.put(`${URL.MOVIES}${id}`, model, {});
};

export const createMovie = (model) => {
  return axiosInstance.post(`${URL.MOVIES}`, model, {});
};

export const deleteMovie = (id) => {
  return axiosInstance.delete(`${URL.MOVIES}${id}`, {});
};

// Sessions
export const getSessions = () => {
  return axiosInstance.get(`${URL.SESSIONS}`, {});
};

export const getSession = (id) => {
  return axiosInstance.get(`${URL.SESSIONS}${id}`, {});
};

export const updateSession = (id, model) => {
  return axiosInstance.put(`${URL.SESSIONS}${id}`, model, {});
};

export const createSession = (model) => {
  return axiosInstance.post(`${URL.SESSIONS}`, model, {});
};

export const deleteSession = (id) => {
  return axiosInstance.delete(`${URL.SESSIONS}${id}`, {});
};

// Rooms
export const getRooms = () => {
  return axiosInstance.get(`${URL.ROOMS}`, {});
};

export const getRoom = (id) => {
  return axiosInstance.get(`${URL.ROOMS}${id}`, {});
};

export const updateRoom = (id, model) => {
  return axiosInstance.put(`${URL.ROOMS}${id}`, model, {});
};

export const createRoom = (model) => {
  return axiosInstance.post(`${URL.ROOMS}`, model, {});
};

export const deleteRoom = (id) => {
  return axiosInstance.delete(`${URL.ROOMS}${id}`, {});
};
