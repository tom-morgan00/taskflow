import { useForm } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import { Button } from "@/components/ui/button";
import {
  FormField,
  FormItem,
  FormLabel,
  FormControl,
  FormMessage,
  Form,
} from "@/components/ui/form";
import {
  Popover,
  PopoverTrigger,
  PopoverContent,
} from "@/components/ui/popover";
import { Input } from "@/components/ui/input";
import {
  Dialog,
  DialogContent,
  DialogDescription,
  DialogHeader,
  DialogTitle,
} from "@/components/ui/dialog";
import { useStore } from "@/lib/store";
import { Textarea } from "@/components/ui/textarea";
import { useNavigate } from "react-router";
import { useEffect } from "react";
import useTasks from "@/lib/hooks/useTasks";
import { cn, formatDate } from "@/lib/utils";
import { formSchema, FormSchema } from "@/lib/schemas/schema";
import { CalendarIcon } from "lucide-react";
import { Calendar } from "@/components/ui/calendar";
import {
  Select,
  SelectTrigger,
  SelectValue,
  SelectContent,
  SelectItem,
} from "@/components/ui/select";

type Props = {
  workspace: Workspace;
  taskId?: string;
  editMode: boolean;
};

export default function TaskForm({ workspace, taskId, editMode }: Props) {
  const navigate = useNavigate();
  const { isTaskFormOpen, closeTaskForm } = useStore();
  const { task, createTask, editTask } = useTasks(taskId);

  console.log("Task changed...", task);

  const form = useForm<FormSchema>({
    mode: "onChange",
    resolver: zodResolver(formSchema),
  });

  useEffect(() => {
    if (task) {
      form.reset({
        ...task,
        dueDate: task.dueDate,
      });
    } else {
      console.log("Resetting form...");
      form.reset({
        name: "",
        status: "ToDo",
        dueDate: undefined,
        description: "",
        workspaceId: workspace.id,
      });
    }
  }, [task, form, workspace]);

  async function onSubmit(values: FormSchema) {
    console.log("submitting: ", values);
    if (task) {
      const data = { ...values, id: task.id } as Task;
      await editTask.mutateAsync(data);
    } else {
      await createTask.mutateAsync(values as Task);
    }
    handleCloseForm();
  }

  const handleCloseForm = () => {
    if (task) {
      navigate(`/app/workspaces/${workspace.id}`, { replace: true });
    }
    form.reset({
      name: "",
      status: "ToDo",
      dueDate: undefined,
      description: "",
      workspaceId: workspace.id,
    });
    closeTaskForm();
  };

  return (
    <Dialog open={isTaskFormOpen} onOpenChange={handleCloseForm}>
      <DialogContent>
        <DialogHeader>
          <DialogTitle>{editMode ? "Edit task" : "Create task"}</DialogTitle>
          <DialogDescription>
            {editMode
              ? "Enter details and update task"
              : "Enter details to create a new task"}
          </DialogDescription>
        </DialogHeader>
        <Form {...form}>
          <form onSubmit={form.handleSubmit(onSubmit)} className="space-y-8">
            <FormField
              control={form.control}
              name="name"
              render={({ field }) => (
                <FormItem>
                  <FormLabel>Name</FormLabel>
                  <FormControl>
                    <Input placeholder="Enter name" {...field} />
                  </FormControl>
                  <FormMessage />
                </FormItem>
              )}
            />
            <div className="flex gap-3">
              <FormField
                control={form.control}
                name="status"
                render={({ field }) => (
                  <FormItem className="w-full">
                    <FormLabel>Status</FormLabel>
                    <Select
                      onValueChange={field.onChange}
                      defaultValue={field.value}
                    >
                      <FormControl>
                        <SelectTrigger>
                          <SelectValue placeholder="Select status" />
                        </SelectTrigger>
                      </FormControl>
                      <SelectContent>
                        <SelectItem value="ToDo">To Do</SelectItem>
                        <SelectItem value="InProgress">In Progress</SelectItem>
                        <SelectItem value="Done">Done</SelectItem>
                      </SelectContent>
                    </Select>
                    <FormMessage />
                  </FormItem>
                )}
              />
              <FormField
                control={form.control}
                name="dueDate"
                render={({ field }) => (
                  <FormItem className="flex flex-col w-full">
                    <FormLabel>Due date</FormLabel>
                    <Popover>
                      <PopoverTrigger asChild>
                        <FormControl>
                          <Button
                            variant={"outline"}
                            className={cn(
                              "w-[240px] pl-3 text-left font-normal",
                              !field.value && "text-muted-foreground"
                            )}
                          >
                            {field.value ? (
                              formatDate(field.value, "yyyy-MM-dd")
                            ) : (
                              <span>Pick a date</span>
                            )}
                            <CalendarIcon className="ml-auto h-4 w-4 opacity-50" />
                          </Button>
                        </FormControl>
                      </PopoverTrigger>
                      <PopoverContent className="w-auto p-0" align="start">
                        <Calendar
                          mode="single"
                          selected={field.value || undefined}
                          onSelect={field.onChange}
                          initialFocus
                        />
                      </PopoverContent>
                    </Popover>
                    <FormMessage />
                  </FormItem>
                )}
              />
            </div>
            <FormField
              control={form.control}
              name="description"
              render={({ field }) => (
                <FormItem>
                  <FormLabel>Description</FormLabel>
                  <FormControl>
                    <Textarea
                      placeholder="Enter description"
                      {...field}
                      className="resize-none min-h-[80px]"
                    />
                  </FormControl>
                  <FormMessage />
                </FormItem>
              )}
            />
            <div className="flex gap-2 justify-end">
              <Button type="button" variant="outline" onClick={handleCloseForm}>
                Cancel
              </Button>
              <Button type="submit">Submit</Button>
            </div>
          </form>
        </Form>
      </DialogContent>
    </Dialog>
  );
}
