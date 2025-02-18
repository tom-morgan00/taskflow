import agent from "@/lib/api/agent";
import { useQuery } from "@tanstack/react-query";

export default function useWorkspaces(id?: string) {
  const getWorkspaces = useQuery({
    queryKey: ["workspaces"],
    queryFn: async () => {
      const result = await agent.get<Workspace[]>("/workspaces");
      return result.data;
    },
  });

  const getWorkspaceById = useQuery({
    queryKey: ["workspaces", id],
    queryFn: async () => {
      const result = await agent.get<Workspace>(`/workspaces/${id}`);
      return result.data;
    },
    enabled: !!id,
  });

  return {
    workspaces: getWorkspaces.data,
    isLoadingWorkspaces: getWorkspaces.isLoading,
    workspace: getWorkspaceById.data,
    isLoadingWorkspace: getWorkspaceById.isLoading,
  };
}
