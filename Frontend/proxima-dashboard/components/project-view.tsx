"use client"

import { useState } from "react"
import { Button } from "@/components/ui/button"
import { Input } from "@/components/ui/input"
import { Avatar, AvatarFallback, AvatarImage } from "@/components/ui/avatar"
import { Checkbox } from "@/components/ui/checkbox"
import {
  DropdownMenu,
  DropdownMenuContent,
  DropdownMenuItem,
  DropdownMenuTrigger,
} from "@/components/ui/dropdown-menu"
import { Calendar, ChevronDown, Filter, MoreHorizontal, Plus, Search, Table, TableProperties } from 'lucide-react'

const groups = [
  {
    name: "Planning Phase",
    items: [
      {
        id: 1,
        name: "Market Research",
        owner: { name: "Sarah K.", image: "/placeholder.svg" },
        status: "Working on it",
        priority: "High",
        dueDate: "Oct 25",
        files: 3,
      },
      {
        id: 2,
        name: "Competitor Analysis",
        owner: { name: "Mike R.", image: "/placeholder.svg" },
        status: "Stuck",
        priority: "Medium",
        dueDate: "Oct 27",
        files: 2,
      },
    ],
  },
  {
    name: "Design Phase",
    items: [
      {
        id: 3,
        name: "Wireframes",
        owner: { name: "Lisa M.", image: "/placeholder.svg" },
        status: "Done",
        priority: "High",
        dueDate: "Oct 30",
        files: 5,
      },
      {
        id: 4,
        name: "UI Design",
        owner: { name: "Tom W.", image: "/placeholder.svg" },
        status: "Working on it",
        priority: "High",
        dueDate: "Nov 5",
        files: 8,
      },
    ],
  },
]

const statusColors = {
  "Working on it": "bg-yellow-100 text-yellow-800",
  "Stuck": "bg-red-100 text-red-800",
  "Done": "bg-green-100 text-green-800",
}

export function ProjectView() {
  const [selectedItems, setSelectedItems] = useState<number[]>([])

  const toggleItem = (itemId: number) => {
    setSelectedItems(prev =>
      prev.includes(itemId)
        ? prev.filter(id => id !== itemId)
        : [...prev, itemId]
    )
  }

  return (
    <div className="flex-1 overflow-hidden">
      <div className="border-b bg-white p-4">
        <div className="flex items-center justify-between mb-4">
          <div className="flex items-center gap-3">
            <h1 className="text-xl font-semibold">Project Planning</h1>
            <Button variant="outline" size="sm">
              <Filter className="h-4 w-4 mr-2" />
              Filter
            </Button>
            <Button variant="outline" size="sm">
              <TableProperties className="h-4 w-4 mr-2" />
              Group by
            </Button>
          </div>
          <div className="flex items-center gap-2">
            <Button variant="outline" size="sm">
              <Table className="h-4 w-4 mr-2" />
              Table view
            </Button>
            <Button size="sm">
              <Plus className="h-4 w-4 mr-2" />
              New Item
            </Button>
          </div>
        </div>
        <div className="flex items-center gap-4">
          <div className="relative flex-1 max-w-md">
            <Search className="absolute left-2 top-2.5 h-4 w-4 text-muted-foreground" />
            <Input placeholder="Search" className="pl-8" />
          </div>
        </div>
      </div>

      <div className="flex-1 overflow-auto">
        <div className="min-w-full">
          <div className="grid grid-cols-[2.5rem_1fr_200px_150px_150px_150px_100px_50px] gap-4 p-2 border-b bg-gray-50/80 text-sm font-medium text-gray-500">
            <div></div>
            <div>Task</div>
            <div>Owner</div>
            <div>Status</div>
            <div>Priority</div>
            <div>Due Date</div>
            <div>Files</div>
            <div></div>
          </div>

          {groups.map((group) => (
            <div key={group.name} className="border-b last:border-0">
              <div className="flex items-center gap-2 p-2 bg-gray-50/50">
                <ChevronDown className="h-4 w-4" />
                <span className="font-medium">{group.name}</span>
              </div>
              {group.items.map((item) => (
                <div
                  key={item.id}
                  className="grid grid-cols-[2.5rem_1fr_200px_150px_150px_150px_100px_50px] gap-4 p-2 items-center hover:bg-gray-50 group"
                >
                  <div className="flex justify-center">
                    <Checkbox
                      checked={selectedItems.includes(item.id)}
                      onCheckedChange={() => toggleItem(item.id)}
                    />
                  </div>
                  <div>{item.name}</div>
                  <div>
                    <Avatar className="h-6 w-6">
                      <AvatarImage src={item.owner.image} />
                      <AvatarFallback>{item.owner.name[0]}</AvatarFallback>
                    </Avatar>
                  </div>
                  <div>
                    <span className={`inline-flex items-center rounded-full px-2 py-1 text-xs font-medium ${statusColors[item.status as keyof typeof statusColors]}`}>
                      {item.status}
                    </span>
                  </div>
                  <div>
                    <span className="inline-flex items-center rounded-full px-2 py-1 text-xs font-medium bg-gray-100">
                      {item.priority}
                    </span>
                  </div>
                  <div className="flex items-center gap-2">
                    <Calendar className="h-4 w-4 text-gray-500" />
                    {item.dueDate}
                  </div>
                  <div>{item.files}</div>
                  <div>
                    <DropdownMenu>
                      <DropdownMenuTrigger asChild>
                        <Button
                          variant="ghost"
                          size="icon"
                          className="h-8 w-8 opacity-0 group-hover:opacity-100"
                        >
                          <MoreHorizontal className="h-4 w-4" />
                        </Button>
                      </DropdownMenuTrigger>
                      <DropdownMenuContent align="end">
                        <DropdownMenuItem>Edit</DropdownMenuItem>
                        <DropdownMenuItem>Delete</DropdownMenuItem>
                        <DropdownMenuItem>Move</DropdownMenuItem>
                      </DropdownMenuContent>
                    </DropdownMenu>
                  </div>
                </div>
              ))}
            </div>
          ))}
        </div>
      </div>
    </div>
  )
}

