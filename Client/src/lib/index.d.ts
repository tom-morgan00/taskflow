type Task = {
  id: string;
  name: string;
  description?: string;
  status: "ToDo" | "InProgress" | "Done";
  dueDate?: string;
  createdAt: string;
  workspaceId: string;
};

type Workspace = {
  id: string;
  name: string;
  createdAt: string;
  tasks: Task[];
};
