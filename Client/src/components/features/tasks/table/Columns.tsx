import { ColumnDef } from "@tanstack/react-table";
import TaskOptions from "./TaskOptions";

export const columns: ColumnDef<Task>[] = [
  {
    accessorKey: "name",
    header: "Name",
  },
  {
    accessorKey: "status",
    header: "Status",
  },
  {
    accessorKey: "dueDate",
    header: "Due date",
  },
  {
    accessorKey: "createdAt",
    header: "Created at",
  },
  {
    id: "actions",
    cell: ({ row }) => {
      const task = row.original;

      return <TaskOptions task={task} />;
    },
  },
];
