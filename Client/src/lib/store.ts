import { create } from "zustand";

interface State {
  isTaskFormOpen: boolean;
  setTaskFormOpen: (option: boolean) => void;
  selectedFormTask?: Task;
  setSelectedFormTask: (task: Task) => void;
}

export const useStore = create<State>((set) => ({
  isTaskFormOpen: false,
  setTaskFormOpen: (option) => set({ isTaskFormOpen: option }),
  setSelectedFormTask: (task) => set({ selectedFormTask: task }),
}));
