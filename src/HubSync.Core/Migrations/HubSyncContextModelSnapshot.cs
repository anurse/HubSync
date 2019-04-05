﻿// <auto-generated />
using System;
using HubSync.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HubSync.Migrations
{
    [DbContext(typeof(HubSyncContext))]
    partial class HubSyncContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0-preview3.19153.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HubSync.Models.Actor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AvatarUrl");

                    b.Property<long?>("GitHubId");

                    b.Property<string>("Login")
                        .IsRequired();

                    b.Property<string>("NodeId");

                    b.HasKey("Id");

                    b.HasIndex("GitHubId")
                        .IsUnique()
                        .HasFilter("[GitHubId] IS NOT NULL");

                    b.ToTable("Actors");
                });

            modelBuilder.Entity("HubSync.Models.Issue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AuthorId");

                    b.Property<string>("Body")
                        .IsRequired();

                    b.Property<DateTimeOffset?>("ClosedAt");

                    b.Property<int>("CommentCount");

                    b.Property<DateTimeOffset>("CreatedAt");

                    b.Property<long?>("GitHubId");

                    b.Property<bool>("IsPullRequest");

                    b.Property<bool>("Locked");

                    b.Property<int?>("MilestoneId");

                    b.Property<string>("NodeId");

                    b.Property<int>("Number");

                    b.Property<int>("RepositoryId");

                    b.Property<string>("State");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<DateTimeOffset?>("UpdatedAt");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("GitHubId")
                        .IsUnique()
                        .HasFilter("[GitHubId] IS NOT NULL");

                    b.HasIndex("MilestoneId");

                    b.HasIndex("RepositoryId");

                    b.ToTable("Issues");

                    b.HasDiscriminator<bool>("IsPullRequest").HasValue(false);
                });

            modelBuilder.Entity("HubSync.Models.IssueAssignee", b =>
                {
                    b.Property<int>("IssueId");

                    b.Property<int>("AssigneeId");

                    b.HasKey("IssueId", "AssigneeId");

                    b.HasIndex("AssigneeId");

                    b.ToTable("IssueAssignees");
                });

            modelBuilder.Entity("HubSync.Models.IssueLabel", b =>
                {
                    b.Property<int>("IssueId");

                    b.Property<int>("LabelId");

                    b.HasKey("IssueId", "LabelId");

                    b.HasIndex("LabelId");

                    b.ToTable("IssueLabels");
                });

            modelBuilder.Entity("HubSync.Models.IssueLink", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IssueId");

                    b.Property<string>("LinkType")
                        .IsRequired();

                    b.Property<int>("Number");

                    b.Property<int>("RepositoryId");

                    b.HasKey("Id");

                    b.HasIndex("IssueId");

                    b.HasIndex("RepositoryId");

                    b.ToTable("IssueLinks");
                });

            modelBuilder.Entity("HubSync.Models.Label", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Color");

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("NodeId");

                    b.Property<int>("RepositoryId");

                    b.HasKey("Id");

                    b.HasIndex("RepositoryId");

                    b.ToTable("Labels");
                });

            modelBuilder.Entity("HubSync.Models.Milestone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset?>("DueOn");

                    b.Property<string>("NodeId");

                    b.Property<int>("Number");

                    b.Property<int>("RepositoryId");

                    b.Property<string>("State")
                        .IsRequired();

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RepositoryId");

                    b.ToTable("Milestones");
                });

            modelBuilder.Entity("HubSync.Models.Repository", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("GitHubId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("NodeId");

                    b.Property<string>("Owner")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("GitHubId")
                        .IsUnique()
                        .HasFilter("[GitHubId] IS NOT NULL");

                    b.ToTable("Repositories");
                });

            modelBuilder.Entity("HubSync.Models.ReviewRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PullRequestId");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("PullRequestId");

                    b.HasIndex("UserId");

                    b.ToTable("ReviewRequest");
                });

            modelBuilder.Entity("HubSync.Models.SyncLogEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset?>("Completed");

                    b.Property<int?>("EndRateLimit");

                    b.Property<int>("RepositoryId");

                    b.Property<int>("StartRateLimit");

                    b.Property<DateTimeOffset>("Started");

                    b.Property<string>("User")
                        .IsRequired();

                    b.Property<DateTimeOffset>("WaterMark");

                    b.HasKey("Id");

                    b.HasIndex("RepositoryId");

                    b.ToTable("SyncLog");
                });

            modelBuilder.Entity("HubSync.Models.PullRequest", b =>
                {
                    b.HasBaseType("HubSync.Models.Issue");

                    b.Property<bool?>("Draft");

                    b.Property<string>("MergeCommitSha");

                    b.Property<DateTimeOffset?>("MergedAt");

                    b.HasDiscriminator().HasValue(true);
                });

            modelBuilder.Entity("HubSync.Models.Issue", b =>
                {
                    b.HasOne("HubSync.Models.Actor", "Author")
                        .WithMany("Issues")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HubSync.Models.Milestone", "Milestone")
                        .WithMany("Issues")
                        .HasForeignKey("MilestoneId");

                    b.HasOne("HubSync.Models.Repository", "Repository")
                        .WithMany("Issues")
                        .HasForeignKey("RepositoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.OwnsOne("HubSync.Models.IssueReactions", "Reactions", b1 =>
                        {
                            b1.Property<int>("IssueId")
                                .ValueGeneratedOnAdd()
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<int>("Confused");

                            b1.Property<int>("Heart");

                            b1.Property<int>("Hooray");

                            b1.Property<int>("Laugh");

                            b1.Property<int>("Minus1");

                            b1.Property<int>("Plus1");

                            b1.Property<int>("TotalCount");

                            b1.HasKey("IssueId");

                            b1.ToTable("Issues");

                            b1.WithOwner()
                                .HasForeignKey("IssueId");
                        });
                });

            modelBuilder.Entity("HubSync.Models.IssueAssignee", b =>
                {
                    b.HasOne("HubSync.Models.Actor", "Assignee")
                        .WithMany("IssueAssignments")
                        .HasForeignKey("AssigneeId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("HubSync.Models.Issue", "Issue")
                        .WithMany("Assignees")
                        .HasForeignKey("IssueId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("HubSync.Models.IssueLabel", b =>
                {
                    b.HasOne("HubSync.Models.Issue", "Issue")
                        .WithMany("Labels")
                        .HasForeignKey("IssueId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("HubSync.Models.Label", "Label")
                        .WithMany("Issues")
                        .HasForeignKey("LabelId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("HubSync.Models.IssueLink", b =>
                {
                    b.HasOne("HubSync.Models.Issue", "Issue")
                        .WithMany("OutboundLinks")
                        .HasForeignKey("IssueId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HubSync.Models.Repository", "TargetRepository")
                        .WithMany()
                        .HasForeignKey("RepositoryId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("HubSync.Models.Label", b =>
                {
                    b.HasOne("HubSync.Models.Repository", "Repository")
                        .WithMany("Labels")
                        .HasForeignKey("RepositoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HubSync.Models.Milestone", b =>
                {
                    b.HasOne("HubSync.Models.Repository", "Repository")
                        .WithMany("Milestones")
                        .HasForeignKey("RepositoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HubSync.Models.ReviewRequest", b =>
                {
                    b.HasOne("HubSync.Models.PullRequest", "PullRequest")
                        .WithMany("ReviewRequests")
                        .HasForeignKey("PullRequestId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HubSync.Models.Actor", "User")
                        .WithMany("ReviewRequests")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HubSync.Models.SyncLogEntry", b =>
                {
                    b.HasOne("HubSync.Models.Repository", "Repository")
                        .WithMany("LogEntries")
                        .HasForeignKey("RepositoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HubSync.Models.PullRequest", b =>
                {
                    b.OwnsOne("HubSync.Models.CommitInfo", "Base", b1 =>
                        {
                            b1.Property<int>("PullRequestId")
                                .ValueGeneratedOnAdd()
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Ref");

                            b1.Property<string>("Sha");

                            b1.HasKey("PullRequestId");

                            b1.ToTable("Issues");

                            b1.WithOwner()
                                .HasForeignKey("PullRequestId");
                        });

                    b.OwnsOne("HubSync.Models.CommitInfo", "Head", b1 =>
                        {
                            b1.Property<int>("PullRequestId")
                                .ValueGeneratedOnAdd()
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Ref");

                            b1.Property<string>("Sha");

                            b1.HasKey("PullRequestId");

                            b1.ToTable("Issues");

                            b1.WithOwner()
                                .HasForeignKey("PullRequestId");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
