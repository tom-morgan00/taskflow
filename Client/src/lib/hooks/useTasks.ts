import agent from "@/lib/api/agent";
import { useMutation, useQuery, useQueryClient } from "@tanstack/react-query";

export default function useTasks(id?: string) {
  const queryClient = useQueryClient();
  const getTasks = useQuery({
    queryKey: ["tasks"],
    queryFn: async () => {
      const result = await agent.get<Task[]>("/tasks");
      return result.data;
    },
  });

  const getTaskById = useQuery({
    queryKey: ["tasks", id],
    queryFn: async () => {
      const result = await agent.get<Task>(`/tasks/${id}`);
      return result.data;
    },
    enabled: !!id,
  });

  const createTask = useMutation({
    mutationFn: async (task: Task) => {
      const result = await agent.post<Task>(`/tasks`, task);
      return result.data;
    },
    onSuccess: (task) => {
      queryClient.invalidateQueries({
        queryKey: ["workspaces", task.workspaceId],
      });
    },
  });

  const editTask = useMutation({
    mutationFn: async (task: Task) => {
      const result = await agent.put<Task>(`/tasks`, task);
      return result.data;
    },
    onSuccess: (task) => {
      queryClient.invalidateQueries({
        queryKey: ["workspaces", task.workspaceId],
      });
    },
  });

  const deleteTask = useMutation({
    mutationFn: async (id: string) => {
      const result = await agent.delete<Task>(`/tasks/${id}`);
      console.log(result.data);
    },
    onSuccess: () => {
      queryClient.invalidateQueries({
        queryKey: ["workspaces"],
      });
    },
  });

  return {
    tasks: getTasks.data,
    isLoadingTasks: getTasks.isLoading,
    task: getTaskById.data,
    isLoadingTask: getTaskById.isLoading,
    createTask,
    editTask,
    deleteTask,
  };
}
