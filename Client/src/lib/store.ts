import { create } from "zustand";

interface State {
  isTaskFormOpen: boolean;
  editMode: boolean;
  openTaskForm: (editMode: boolean) => void;
  closeTaskForm: () => void;
}

export const useStore = create<State>((set) => ({
  isTaskFormOpen: false,
  editMode: false,
  openTaskForm: (editMode: boolean) => set({ isTaskFormOpen: true, editMode }),
  closeTaskForm: () => set({ isTaskFormOpen: false, editMode: false }),
}));
