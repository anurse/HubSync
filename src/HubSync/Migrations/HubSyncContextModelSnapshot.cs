﻿// <auto-generated />
using HubSync.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace HubSync.Migrations
{
    [DbContext(typeof(HubSyncContext))]
    partial class HubSyncContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-preview2-25502")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HubSync.Models.Issue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Body");

                    b.Property<DateTimeOffset?>("ClosedAt");

                    b.Property<int?>("ClosedById");

                    b.Property<int>("CommentCount");

                    b.Property<DateTimeOffset>("CreatedAt");

                    b.Property<int>("GitHubId");

                    b.Property<string>("HtmlUrl");

                    b.Property<bool>("IsPr");

                    b.Property<bool>("Locked");

                    b.Property<int?>("MilestoneId");

                    b.Property<int>("Number");

                    b.Property<string>("PullRequestUrl");

                    b.Property<int>("RepositoryId");

                    b.Property<int>("State");

                    b.Property<string>("Title");

                    b.Property<DateTimeOffset?>("UpdatedAt");

                    b.Property<string>("Url");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasAlternateKey("GitHubId");


                    b.HasAlternateKey("Number", "RepositoryId");

                    b.HasIndex("ClosedById");

                    b.HasIndex("MilestoneId");

                    b.HasIndex("RepositoryId");

                    b.HasIndex("UserId");

                    b.ToTable("Issues");
                });

            modelBuilder.Entity("HubSync.Models.IssueAssignee", b =>
                {
                    b.Property<int>("IssueId");

                    b.Property<int>("UserId");

                    b.HasKey("IssueId", "UserId");

                    b.HasIndex("UserId");

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

            modelBuilder.Entity("HubSync.Models.Label", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Color");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("RepositoryId");

                    b.HasKey("Id");

                    b.HasAlternateKey("RepositoryId", "Name");

                    b.ToTable("Labels");
                });

            modelBuilder.Entity("HubSync.Models.Milestone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Number");

                    b.Property<int>("RepositoryId");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasAlternateKey("RepositoryId", "Number");

                    b.ToTable("Milestones");
                });

            modelBuilder.Entity("HubSync.Models.Repository", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("GitHubId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Owner")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAlternateKey("GitHubId");


                    b.HasAlternateKey("Owner", "Name");

                    b.ToTable("Repositories");
                });

            modelBuilder.Entity("HubSync.Models.SyncHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Agent");

                    b.Property<DateTime?>("CompletedUtc");

                    b.Property<DateTime>("CreatedUtc");

                    b.Property<string>("Error");

                    b.Property<int>("RepositoryId");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.HasIndex("RepositoryId");

                    b.ToTable("SyncHistory");
                });

            modelBuilder.Entity("HubSync.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AvatarUrl");

                    b.Property<int>("GitHubId");

                    b.Property<string>("Login")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAlternateKey("GitHubId");


                    b.HasAlternateKey("Login");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("HubSync.Models.PullRequest", b =>
                {
                    b.Property<int?>("IssueId");

                    b.Property<string>("BaseRef");

                    b.Property<string>("BaseSha");

                    b.Property<int>("ChangedFiles");

                    b.Property<string>("HeadRef");

                    b.Property<string>("HeadSha");

                    b.Property<bool>("IsPr");

                    b.Property<bool?>("Mergeable");

                    b.Property<DateTimeOffset?>("MergedAt");

                    b.Property<int?>("MergedById");

                    b.HasKey("IssueId");

                    b.HasIndex("MergedById");

                    b.ToTable("Issues");
                });

            modelBuilder.Entity("HubSync.Models.Issue", b =>
                {
                    b.HasOne("HubSync.Models.User", "ClosedBy")
                        .WithMany("ClosedIssues")
                        .HasForeignKey("ClosedById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("HubSync.Models.Milestone", "Milestone")
                        .WithMany("Issues")
                        .HasForeignKey("MilestoneId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("HubSync.Models.Repository", "Repository")
                        .WithMany("Issues")
                        .HasForeignKey("RepositoryId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("HubSync.Models.User", "User")
                        .WithMany("CreatedIssues")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("HubSync.Models.IssueAssignee", b =>
                {
                    b.HasOne("HubSync.Models.Issue", "Issue")
                        .WithMany("Assignees")
                        .HasForeignKey("IssueId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HubSync.Models.User", "User")
                        .WithMany("AssignedIssues")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("HubSync.Models.IssueLabel", b =>
                {
                    b.HasOne("HubSync.Models.Issue", "Issue")
                        .WithMany("Labels")
                        .HasForeignKey("IssueId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HubSync.Models.Label", "Label")
                        .WithMany("Issues")
                        .HasForeignKey("LabelId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HubSync.Models.Label", b =>
                {
                    b.HasOne("HubSync.Models.Repository", "Repository")
                        .WithMany("Labels")
                        .HasForeignKey("RepositoryId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("HubSync.Models.Milestone", b =>
                {
                    b.HasOne("HubSync.Models.Repository", "Repository")
                        .WithMany("Milestones")
                        .HasForeignKey("RepositoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HubSync.Models.SyncHistory", b =>
                {
                    b.HasOne("HubSync.Models.Repository", "Repository")
                        .WithMany("HistoryEntries")
                        .HasForeignKey("RepositoryId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("HubSync.Models.PullRequest", b =>
                {
                    b.HasOne("HubSync.Models.Issue")
                        .WithOne("PullRequest")
                        .HasForeignKey("HubSync.Models.PullRequest", "IssueId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HubSync.Models.User", "MergedBy")
                        .WithMany()
                        .HasForeignKey("MergedById");
                });
        }
    }
}
