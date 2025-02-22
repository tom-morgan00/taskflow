import { Button } from "@/components/ui/button";
import useWorkspaces from "@/lib/hooks/useWorkspaces";
import { PlusIcon } from "lucide-react";
import { useParams, useSearchParams } from "react-router";
import { TaskTable } from "@/components/features/tasks/table/TaskTable";
import { columns } from "@/components/features/tasks/table/Columns";
import TaskForm from "../tasks/TaskForm";
import { useStore } from "@/lib/store";
import { useEffect } from "react";

export default function WorkspaceList() {
  const { id: workspaceId } = useParams();
  const [searchParams] = useSearchParams();
  const taskId = searchParams.get("task") || undefined;
  const { workspace, isLoadingWorkspace } = useWorkspaces(workspaceId);
  const { openTaskForm, closeTaskForm, editMode } = useStore();

  useEffect(() => {
    if (taskId) {
      openTaskForm(true);
    } else {
      closeTaskForm();
    }
  }, [taskId, openTaskForm, closeTaskForm]);

  if (isLoadingWorkspace) {
    return <div>Loading...</div>;
  }

  if (!workspace) {
    return <div>Workspace not found.</div>;
  }

  return (
    <main className="flex flex-col gap-4">
      <TaskForm workspace={workspace} taskId={taskId} editMode={editMode} />
      <div className="flex justify-between">
        <h1 className="text-2xl">{workspace.name}</h1>
        <Button onClick={() => openTaskForm(false)}>
          <PlusIcon /> New task
        </Button>
      </div>
      <div className="flex flex-col gap-2">
        <TaskTable data={workspace.tasks} columns={columns} />
      </div>
    </main>
  );
}
