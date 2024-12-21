"use client"

import { useState } from "react"
import { Button } from "@/components/ui/button"
import { Input } from "@/components/ui/input"
import { Avatar, AvatarFallback, AvatarImage } from "@/components/ui/avatar"
import { Badge } from "@/components/ui/badge"
import {
  DropdownMenu,
  DropdownMenuContent,
  DropdownMenuItem,
  DropdownMenuTrigger,
} from "@/components/ui/dropdown-menu"
import { Filter, Grid, LayoutGrid, MoreHorizontal, Plus, Search } from 'lucide-react'

const groups = [
  {
    name: "Planning Phase",
    color: "bg-blue-100",
    items: [
      {
        id: 1,
        name: "Market Research",
        description: "Analyze market trends and competitor strategies",
        owner: { name: "Sarah K.", image: "/placeholder.svg" },
        status: "Working on it",
        priority: "High",
        dueDate: "Oct 25",
        progress: 65,
        members: [
          { name: "Alex M.", image: "/placeholder.svg" },
          { name: "John D.", image: "/placeholder.svg" },
        ]
      },
      {
        id: 2,
        name: "Competitor Analysis",
        description: "Deep dive into competitor features and pricing",
        owner: { name: "Mike R.", image: "/placeholder.svg" },
        status: "Stuck",
        priority: "Medium",
        dueDate: "Oct 27",
        progress: 30,
        members: [
          { name: "Lisa P.", image: "/placeholder.svg" },
        ]
      },
    ],
  },
  {
    name: "Design Phase",
    color: "bg-purple-100",
    items: [
      {
        id: 3,
        name: "Wireframes",
        description: "Create low-fidelity wireframes for key pages",
        owner: { name: "Lisa M.", image: "/placeholder.svg" },
        status: "Done",
        priority: "High",
        dueDate: "Oct 30",
        progress: 100,
        members: [
          { name: "Tom W.", image: "/placeholder.svg" },
          { name: "Sarah K.", image: "/placeholder.svg" },
        ]
      },
      {
        id: 4,
        name: "UI Design",
        description: "Design high-fidelity mockups",
        owner: { name: "Tom W.", image: "/placeholder.svg" },
        status: "Working on it",
        priority: "High",
        dueDate: "Nov 5",
        progress: 45,
        members: [
          { name: "Mike R.", image: "/placeholder.svg" },
          { name: "Lisa M.", image: "/placeholder.svg" },
        ]
      },
    ],
  },
]

const statusColors = {
  "Working on it": "bg-yellow-100 text-yellow-800",
  "Stuck": "bg-red-100 text-red-800",
  "Done": "bg-green-100 text-green-800",
}

export function ProjectBoard() {
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
              <LayoutGrid className="h-4 w-4 mr-2" />
              Group by
            </Button>
          </div>
          <div className="flex items-center gap-2">
            <Button variant="outline" size="sm">
              <Grid className="h-4 w-4 mr-2" />
              Board view
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

      <div className="flex-1 overflow-auto p-6">
        <div className="flex gap-6">
          {groups.map((group) => (
            <div key={group.name} className="flex-1 min-w-[350px] max-w-md">
              <div className={`rounded-t-lg p-3 ${group.color}`}>
                <h3 className="font-medium">{group.name}</h3>
              </div>
              <div className="flex flex-col gap-3 mt-3">
                {group.items.map((item) => (
                  <div
                    key={item.id}
                    className="bg-white rounded-lg border shadow-sm hover:shadow-md transition-shadow"
                  >
                    <div className="p-4">
                      <div className="flex items-start justify-between">
                        <h4 className="font-medium">{item.name}</h4>
                        <DropdownMenu>
                          <DropdownMenuTrigger asChild>
                            <Button variant="ghost" size="icon" className="h-8 w-8">
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
                      <p className="text-sm text-gray-500 mt-1">{item.description}</p>
                      <div className="mt-4 space-y-3">
                        <div className="flex items-center justify-between text-sm">
                          <span className="text-gray-500">Progress</span>
                          <span className="font-medium">{item.progress}%</span>
                        </div>
                        <div className="w-full bg-gray-200 rounded-full h-1.5">
                          <div
                            className="bg-blue-600 h-1.5 rounded-full"
                            style={{ width: `${item.progress}%` }}
                          />
                        </div>
                        <div className="flex items-center justify-between">
                          <Badge
                            variant="secondary"
                            className={statusColors[item.status as keyof typeof statusColors]}
                          >
                            {item.status}
                          </Badge>
                          <Badge variant="outline">{item.priority}</Badge>
                        </div>
                        <div className="flex items-center justify-between text-sm">
                          <div className="flex -space-x-2">
                            {item.members.map((member, index) => (
                              <Avatar key={index} className="h-6 w-6 border-2 border-white">
                                <AvatarImage src={member.image} />
                                <AvatarFallback>{member.name[0]}</AvatarFallback>
                              </Avatar>
                            ))}
                          </div>
                          <span className="text-gray-500">{item.dueDate}</span>
                        </div>
                      </div>
                    </div>
                  </div>
                ))}
              </div>
            </div>
          ))}
        </div>
      </div>
    </div>
  )
}

