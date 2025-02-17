type Task = {
  id: string;
  name: string;
  description?: string;
  status: number;
  dueDate?: string;
  createdAt: string;
  workspace: Workspace;
};

type Workspace = {
  id: string;
  name: string;
  createdAt: string;
};
